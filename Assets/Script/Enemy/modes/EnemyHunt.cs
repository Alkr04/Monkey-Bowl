using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunt : EnemyModeBase
{
    [SerializeField] Transform mark = null;
    public override void phase()
    {
        if (mark != null)
        {
            agent.SetDestination(mark.position);
        }
        else
        {
            Debug.Log("newMark");
            NewMark();

        }
    }

    void NewMark()
    {
        mark = Manager.Instance.eateble[Random.Range(0, Manager.Instance.eateble.Count)].transform;
    }
}
