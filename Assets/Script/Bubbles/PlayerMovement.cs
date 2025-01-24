using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    WishedDirectionHandler wishedDirectionHandler;
    [SerializeField] float weight;

    private void Awake()
    {
        wishedDirectionHandler = GetComponent<WishedDirectionHandler>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        wishedDirectionHandler.AddDirection(direction, weight);
    }
}
