using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] float respawnTime;
    GameObject bubbleObject;
    Eating eating;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        eating = Instantiate(bubble, transform.transform).GetComponentInChildren<Eating>();
        eating.transform.tag = "Enemy";
        Manager.Instance.AddToEatable(eating.gameObject);
        eating.popped += Respawn;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCorutine());
    }

    IEnumerator RespawnCorutine()
    {
        yield return new WaitForSeconds(respawnTime);
        Spawn();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(1, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 1);
    }

    private void OnDisable()
    {
        eating.popped -= Respawn;
    }
}
