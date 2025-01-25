using System.Collections;
using System.Collections.Generic;
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
        otherRigidBody.velocity = camraForward * launchSpeed;
    }

    private void HalvSize(Eating eating)
    {
        eating.size /= 2;
        eating.SetSize();
    }

    private EnemyMode[] getOtherHalfOfAvatars()
    {
        // return the avatars
        return null;
    }
}
