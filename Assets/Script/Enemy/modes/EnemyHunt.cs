using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyHunt : EnemyModeBase
{
    [SerializeField] Transform mark = null;
    List<GameObject> list;
    public override void phase()
    {
        if (mark != null)
        {
            agent.SetDestination(new Vector3(mark.position.x, transform.position.y, mark.position.z));
        }
        else
        {
            //Debug.Log("newMark");
            NewMark();

        }
    }

    void NewMark()
    {
        list = Manager.Instance.eateble.Keys.ToList();
        mark = list[Random.Range(0, Manager.Instance.eateble.Count)].transform;
        //mark = Manager.Instance.eateble[gameObject];
    }
}
