using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    [HideInInspector] public BubbleMovement bubbleMovement;
    public float size;
    public string eatableTag;

    public Action popped;

    private void Awake()
    {
        bubbleMovement = GetComponent<BubbleMovement>();
    }

    private void Start()
    {
        SetSize();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent == transform.parent || other.tag != eatableTag) { return; }

        Eating enemy = other.transform.parent.parent.GetComponentInChildren<Eating>();
        if (enemy != null)
        {
            if (enemy.size < size || enemy.bubbleMovement == null)
            {
                size = size + enemy.size;
                SetSize();
                Destroy(other.transform.parent.parent.gameObject);
            }
        }
    }

    public void SetSize()
    {
        if (bubbleMovement) { bubbleMovement.size = size; }
        transform.localScale = Vector3.one * Mathf.Pow(size, 0.3333f);
    }

    private void OnDestroy()
    {
        popped?.Invoke();
    }
}
