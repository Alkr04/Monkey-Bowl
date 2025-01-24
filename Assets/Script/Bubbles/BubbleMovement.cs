using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    Rigidbody bubbleRigidbody;

    public Vector3 wishedDirection;
    public float size;

    [SerializeField] AnimationCurve sizeSpeedRatio;

    public Action Moved;


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
        angularVelocity += wishedDirection.normalized * acceleration;
        bubbleRigidbody.angularVelocity = angularVelocity;
        Moved?.Invoke();
    }
}
