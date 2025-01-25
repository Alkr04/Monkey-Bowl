using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Video;

public class BubbleAnimator : MonoBehaviour
{

    public Animator bubbleDeformAnimator;
    public Animator playerAnimator;
    public Transform playerPieceTransform;

    public Transform physicalBubble;
    public Transform visualBubble;
    public Transform visualBubbleParent;

    Vector3 playerLookDirection = new Vector3(0,0,0);
    Vector3 lastLookLocation = new Vector3(0,0,0);
    BubbleMovement movement;

    private void Awake() {
        movement = GetComponent<BubbleMovement>();
    }

    private void Update() {
        visualBubble.rotation = physicalBubble.rotation;
        visualBubbleParent.localScale = physicalBubble.localScale;


        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            playerLookDirection = Vector3.Normalize(new Vector3(movement.wishedDirection.x, 0, movement.wishedDirection.z));
            lastLookLocation = Vector3.Lerp(lastLookLocation, playerLookDirection, 0.05f);

            Vector3 rotatedLookLocation = Quaternion.Euler(0, 270, 0) * lastLookLocation;

            playerPieceTransform.LookAt(playerAnimator.transform.position + rotatedLookLocation);
            Debug.Log($"playerRotation: {playerAnimator.transform.rotation}");

            playerAnimator.SetBool($"IsJumping", true);
        }
        else
        {
            playerAnimator.SetBool($"IsJumping", false); 
        }
    }
    
    private void OnCollisionEnter(Collision other) {

        if(bubbleDeformAnimator == null) return;

        Vector3 globalPositionOfContact = other.contacts[0].point;

        Vector3 contactVector = Vector3.Normalize(transform.position - globalPositionOfContact);


        if(Vector3.Angle(contactVector, Vector3.down) < 45)
        {
            bubbleDeformAnimator.Play($"BubbleBounceFloor");
        }
        else
        {
            bubbleDeformAnimator.Play($"BubbleBounceWall");
        }
    }
}
