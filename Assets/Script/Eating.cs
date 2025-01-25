using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    [HideInInspector] public BubbleMovement bubbleMovement;
    [HideInInspector] public bool wasSplited = false;
    [HideInInspector] public float timeCreated;
    public float size;
    public string eatableTag;

    [SerializeField] Transform eatObject;
    [SerializeField] float timeToBeEatable = 1;
    
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
        if (wasSplited && !enemy.wasSplited) { return; }

        if (enemy != null)
        {
            if ((enemy.wasSplited && enemy.timeCreated < Time.time - timeToBeEatable) || enemy.size < size || enemy.bubbleMovement == null)
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
        Vector3 scale = Vector3.one * Mathf.Pow(size, 0.3333f);
        transform.localScale = scale;
        eatObject.localScale = scale * 0.7f;
    }

    private void OnDestroy()
    {
        popped?.Invoke();
    }
}
