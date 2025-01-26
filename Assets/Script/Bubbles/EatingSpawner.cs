using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingSpawner : MonoBehaviour
{
    [SerializeField] GameObject eatingBubbleBase;
    [SerializeField] Vector3 size;
    [SerializeField] float timeToSpawnAttempt;
    [SerializeField] LayerMask layerMask;

    Vector3 temp = Vector3.one;

    Vector3[] moorNeighbours = { new(1,0,1), new(1,0,0), new(1,0,-1),
                                new (0,0,1), new(0,0,-1),
                                new(-1,0,1), new(-1,0,0), new(-1,0,-1)};

    private void Start()
    {
        StartCoroutine(SpawnCicle());
    }

    IEnumerator SpawnCicle()
    {
        yield return new WaitForSeconds(timeToSpawnAttempt);

        SpawnBubble();
        StartCoroutine(SpawnCicle());
    }

    private void SpawnBubble()
    {
        Vector3 halfSize = size / 2;
        Vector3 spawnPoint = new Vector3(Random.Range(-halfSize.x, halfSize.x), halfSize.y, Random.Range(-halfSize.z, halfSize.z));
        if (Physics.Raycast(spawnPoint + transform.position, Vector3.down, out RaycastHit hit, size.y))
        {
            if (hit.transform.gameObject.layer != 9) { return; }
            foreach (Vector3 pos in moorNeighbours)
            {
                if (Physics.Raycast(spawnPoint + transform.position + pos / 2, Vector3.down, out _, size.y, layerMask)) { return; }
            }

            temp = hit.point;

            GameObject bubble = Instantiate(eatingBubbleBase, hit.point, Quaternion.identity, transform);
            Eating newEating = bubble.GetComponentInChildren<Eating>();
            newEating.transform.tag = "Enemy";
            Manager.Instance.AddToEatable(newEating.gameObject);
            bubble.transform.position += new Vector3(0, Mathf.Pow(newEating.size, 0.3333f) / 2, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(1, 0, 1, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
}
