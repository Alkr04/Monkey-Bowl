using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAttach : MonoBehaviour
{
    BubbleMovement BubbleMovement;

    private void Awake()
    {
        BubbleMovement = transform.root.GetComponentInChildren<BubbleMovement>();
    }

    private void Update()
    {
        transform.position = BubbleMovement.transform.position;
    }
}
