using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyModeBase : MonoBehaviour
{
    public PlayerMovement player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    public void Start()
    {
        //Debug.Log("start");
        player = FindObjectOfType<PlayerMovement>();
        agent = GetComponentInParent<NavMeshAgent>();
    }
    public abstract void phase();

    private void ResetPosition()
    {
        agent.SetDestination(transform.position);
    }


}
