using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleSplit : MonoBehaviour
{
    Eating eating;
    Rigidbody rb;

    [SerializeField] float launchSpeed;
    [SerializeField] float retractSpeed;
    [SerializeField] float minimunSize;
    [SerializeField] GameObject bubbleBase;

    private void Awake()
    {
        eating = GetComponent<Eating>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && minimunSize < eating.size) { Split(); }
    }

    private void Split()
    {
        Vector3 camraForward = Camera.main.transform.forward;
        HalvSize(eating);
        rb.velocity += -camraForward * retractSpeed;

        var other = Instantiate(bubbleBase, transform.position, Quaternion.identity, null);
        Eating otherEating = other.GetComponentInChildren<Eating>();
        Rigidbody otherRigidBody = other.GetComponentInChildren<Rigidbody>();

        otherEating.size = eating.size;
        otherEating.SetSize();
        otherEating.wasSplited = true;
        otherEating.timeCreated = Time.time;
        otherEating.transform.tag = "Enemy";
        Manager.Instance.AddToEatable(otherEating.gameObject);
        otherRigidBody.velocity = camraForward * launchSpeed;

        StartCoroutine(GetOtherHalfOfAvatars(camraForward, other, otherEating));
    }

    private void HalvSize(Eating eating)
    {
        eating.size /= 2;
        eating.SetSize();
    }

    IEnumerator GetOtherHalfOfAvatars(Vector3 splitDirection, GameObject other, Eating eating)
    {
        yield return new WaitForFixedUpdate();
        EnemyMovment[] allEnemys = GetComponents<EnemyMovment>();
        foreach (EnemyMovment item in allEnemys)
        {
            if (Vector3.Dot(new Vector3(-item.lastWishedDirection.z, item.lastWishedDirection.y, item.lastWishedDirection.x), splitDirection) > 0)
            {
                var bubbleMovement = other.GetComponentInChildren<BubbleMovement>();
                var newMove = bubbleMovement.gameObject.AddComponent<EnemyMovment>();
                newMove.weigth = item.weigth;
                newMove.counterpart = item.counterpart;
                newMove.wishedDirection = bubbleMovement.GetComponent<WishedDirectionHandler>();
                item.counterpart.transform.SetParent(eating.agentsHolder.transform, true);
                Destroy(item);
            }
        }
    }
}
