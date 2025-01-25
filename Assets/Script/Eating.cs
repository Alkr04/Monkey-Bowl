using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    BubbleMovement BubbleMovement;

    private void Awake()
    {
        BubbleMovement = GetComponent<BubbleMovement>();
    }

    private void Start()
    {
        SetSize();
    }

    public float size = 1;
    [SerializeField] Eating enemy;
    Collider test;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bubble")
        {
            Physics.IgnoreCollision(collision.collider, test);
        }

        if (collision.gameObject.GetComponent<Eating>() != null)
        {
            enemy = collision.gameObject.GetComponent<Eating>();
            Debug.Log(enemy);
            if (enemy.size < size)
            {
                size = size + enemy.size;
                SetSize();
                Destroy(collision.transform.root.gameObject);
            }
        }
    }

    private void SetSize()
    {
        BubbleMovement.size = size;
        transform.localScale = transform.localScale * size;
    }
}
