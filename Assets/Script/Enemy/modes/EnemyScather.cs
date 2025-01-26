using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScather : EnemyModeBase
{
    Vector3 target;
    private void Start()
    {
        base.Start();
        agent.SetDestination(GetRandomLocation());
    }

    public void newdestenation()
    {
        target = new Vector3(Random.Range(0, 4), 0, Random.Range(0, 4));
    }

    public override void phase()
    {
        if(agent.remainingDistance <= 5)
        {
            agent.SetDestination(GetRandomLocation());
            
        }
    }
    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);
        //Debug.Log(navMeshData.indices.Length);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }

}
