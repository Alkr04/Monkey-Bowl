using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    WishedDirectionHandler wishedDirectionHandler;
    [SerializeField] float weight = 1;

    private void Awake()
    {
        wishedDirectionHandler = GetComponent<WishedDirectionHandler>();
    }

    private void Update()
    {
        HandleInput(); 
    }

    public void HandleInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new(x, 0 ,z);
        //direction -= x * Camera.main.transform.forward;
        //direction += z * Camera.main.transform.right;

        wishedDirectionHandler.AddDirection(direction.normalized, weight);
    }
}
