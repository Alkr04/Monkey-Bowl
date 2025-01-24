using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    PlayerMovement player;

    [SerializeField] float distanceToPlayer;
    [SerializeField] float cameraLookAhead;

    Vector3 playerPos;
    Vector3 playerPosDelta;
    Vector3 newPos;
    Vector3 deltaNormed;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        playerPos = player.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPlayerPos = player.transform.position;
        playerPosDelta = newPlayerPos - playerPos;
        playerPos = newPlayerPos;
    }

    private void Update()
    {
        if (playerPosDelta.magnitude < 0.01f || playerPosDelta == default) { return; }
        Vector3 deltaNormed = playerPosDelta.normalized;
        Vector3 wishedPos = playerPos + -deltaNormed * distanceToPlayer + new Vector3(0, 3, 0);
        Vector3 newPos;
        newPos.x = Mathf.Lerp(transform.position.x, wishedPos.x, 0.5f);
        newPos.y = Mathf.Lerp(transform.position.y, wishedPos.y, 0.5f);
        newPos.z = Mathf.Lerp(transform.position.z, wishedPos.z, 0.5f);

        this.newPos = newPos;
        this.deltaNormed = deltaNormed;
    }

    private void LateUpdate()
    {
        transform.position = newPos;
        transform.LookAt(playerPos + deltaNormed * cameraLookAhead);
    }
}
