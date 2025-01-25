using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    BubbleMovement BubbleMovement;
    public float size;
    public string eatableTag;

    private void Awake()
    {
        BubbleMovement = GetComponent<BubbleMovement>();
    }

    private void Start()
    {
        SetSize();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == transform.root || other.tag != eatableTag) { return; }
        Eating enemy = other.transform.root.GetComponentInChildren<Eating>();
        if (enemy != null)
        {
            if (enemy.size < size)
            {
                size = size + enemy.size;
                SetSize();
                Destroy(other.transform.root.gameObject);
            }
        }
    }

    public void SetSize()
    {
        Debug.Log(size);
        if (BubbleMovement) { BubbleMovement.size = size; }
        transform.localScale = Vector3.one * Mathf.Pow(size, 0.3333f);
    }
}
