using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishedDirectionHandler : MonoBehaviour
{
    BubbleMovement bubbleMovement;
    
    List<Vector3> directions = new List<Vector3>();
    List<float> weights = new List<float>();

    WishedDirectionHandler instance;

    float totalWeight = 0;

    private void Awake()
    {
        bubbleMovement = GetComponent<BubbleMovement>();
    }

    public void AddDirection(Vector3 direction, float weight)
    {
        directions.Add(direction);
        weights.Add(weight);
    }

    private void LateUpdate()
    {
        totalWeight = 0;
        foreach (float weight in weights) { totalWeight += weight; }
        Vector3 wishedDirection = new();
        for ( int i = 0; i < directions.Count; i++)
        {
            wishedDirection += directions[i] * weights[i] / totalWeight;
        }

        bubbleMovement.wishedDirection = wishedDirection;
        directions.Clear();
        weights.Clear();
    }
}
