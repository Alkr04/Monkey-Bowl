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
        SoundHolder.Instance.PlaySound(SoundHolder.soundCatagory.pop, transform.position, true);

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
        int random = Random.Range(0, allEnemys.Length);
        for (int i = 0; i < allEnemys.Length; i++)
        {
            if (i == random)
            {
                var bubbleMovement = other.GetComponentInChildren<BubbleMovement>();
                var newMove = bubbleMovement.gameObject.AddComponent<EnemyMovment>();
                newMove.weigth = allEnemys[i].weigth;
                newMove.counterpart = allEnemys[i].counterpart;
                newMove.wishedDirection = bubbleMovement.GetComponent<WishedDirectionHandler>();
                allEnemys[i].counterpart.transform.SetParent(eating.agentsHolder.transform, true);
                Destroy(allEnemys[i]);
                Counter.Instance.SetCount(allEnemys.Length - 2);
            }
        }
    }
}
