using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField] public WishedDirectionHandler wishedDirection;
    [SerializeField] public float weigth = 0;
    [SerializeField] public Transform counterpart;

    [HideInInspector] public Vector3 lastWishedDirection;


    // Start is called before the first frame update
    void Awake()
    {
        wishedDirection = GetComponent<WishedDirectionHandler>();
        try { counterpart = transform.parent.GetComponentInChildren<EnemyMode>().transform; }
        catch { Debug.Log("HERE"); }
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
        Vector3 normed = direction.normalized;
        lastWishedDirection = normed;

        wishedDirection.AddDirection(normed, weigth);
    }
}
