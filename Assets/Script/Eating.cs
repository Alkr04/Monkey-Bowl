using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public float size = 1;
    [SerializeField] Eating enemy;
    Collider test;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                GetComponentInChildren<Transform>().localScale = transform.localScale * size;
                Destroy(collision.gameObject);
            }
        }
    }
}
