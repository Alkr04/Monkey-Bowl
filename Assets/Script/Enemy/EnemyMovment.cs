using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField ]WishedDirectionHandler wishedDirection;
    [SerializeField] float weigth = 0;
    [SerializeField] Transform counterpart;


    // Start is called before the first frame update
    void Awake()
    {
        wishedDirection = GetComponent<WishedDirectionHandler>();
        counterpart = transform.parent.GetComponentInChildren<EnemyMode>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Input();
    }

    void Input()
    {
        //Debug.Log("input");
        Vector3 direction = new Vector3((counterpart.position.z - transform.position.z), 0, -(counterpart.position.x - transform.position.x));
        Debug.DrawRay(transform.position, direction);

        wishedDirection.AddDirection(direction.normalized, weigth);
    }
}
