using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] LayerMask layerMask;

    Transform cameraTransform;
    Transform bubbleTransform;
    Vector3 standardCamera;
    Vector2 lastMousePos;
    Vector3 lookDirection;
    float dist;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        bubbleTransform = transform.root.GetComponentInChildren<BubbleMovement>().transform;
        standardCamera = cameraTransform.localPosition;
        dist = standardCamera.magnitude;
    }

    private void LateUpdate()
    {
        Vector2 mousePos = Input.mousePosition;

        if (lastMousePos != default && Input.GetMouseButton(0))
        {
            Vector2 mouseDelta = mousePos - lastMousePos;
            lookDirection += new Vector3(0, mouseDelta.x, mouseDelta.y);
            lookDirection.y = lookDirection.y % 360;
            lookDirection.z = Mathf.Clamp(lookDirection.z, -20, 80);
            transform.eulerAngles = lookDirection;
        }

        cameraTransform.LookAt(bubbleTransform.position);
        if (Physics.Raycast(transform.position, cameraTransform.position - transform.position, out RaycastHit hit, dist, layerMask))
        {
            cameraTransform.position = hit.point;
        }
        else
        {
            cameraTransform.localPosition = standardCamera;
        }
        Debug.DrawRay(transform.position, cameraTransform.position - transform.position, Color.red);


        lastMousePos = mousePos;
    }
}
