using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishedDirectionHandler : MonoBehaviour
{
    BubbleMovement bubbleMovement;
    
    List<Vector3> directions = new List<Vector3>();
    List<float> weights = new List<float>();

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
        Vector3 wishedDirection = new();
        for ( int i = 0; i < directions.Count; i++)
        {
            Debug.Log(weights[i] + " " + directions[i]);
            wishedDirection += directions[i] * weights[i];
        }

        bubbleMovement.wishedDirection = wishedDirection;
        directions.Clear();
    }
}
