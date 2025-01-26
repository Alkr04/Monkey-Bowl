using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    Rigidbody bubbleRigidbody;

    public Vector3 wishedDirection;
    [HideInInspector] public float size;

    [SerializeField] AnimationCurve sizeSpeedRatio;

    private void Awake()
    {
        bubbleRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Roll();
    }

    private void Roll()
    {
        Vector3 angularVelocity =  bubbleRigidbody.angularVelocity;
        float acceleration = sizeSpeedRatio.Evaluate(size);
        angularVelocity += wishedDirection * acceleration;
        bubbleRigidbody.angularVelocity = angularVelocity;
    }

    private void OnDisable()
    {
        Manager.Instance.eateble.Remove(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SoundHolder.Instance.PlaySound(SoundHolder.soundCatagory.bounce, transform.position, true);
    }
}
