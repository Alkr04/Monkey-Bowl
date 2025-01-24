using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTest : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 spot;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(spot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
