using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eating : MonoBehaviour
{
    [HideInInspector] public BubbleMovement bubbleMovement;
    [HideInInspector] public bool wasSplited = false;
    [HideInInspector] public float timeCreated;
    public Transform agentsHolder;
    public float size;
    public string eatableTag;

    [SerializeField] Transform eatObject;
    [SerializeField] float timeToBeEatable = 1;

    public Action popped;

    private void Awake()
    {
        bubbleMovement = GetComponent<BubbleMovement>();
    }

    private void Start()
    {
        SetSize();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent == transform.parent || other.tag != eatableTag) { return; }
        Eating enemy = other.transform.parent.parent.GetComponentInChildren<Eating>();
        if (wasSplited && !enemy.wasSplited) { return; }

        if (enemy != null)
        {
            if ((enemy.wasSplited && enemy.timeCreated < Time.time - timeToBeEatable) || enemy.size < size || enemy.bubbleMovement == null)
            {
                if (Manager.Instance.eateble.ContainsKey(enemy.gameObject)) { Manager.Instance.eateble.Remove(enemy.gameObject); }
                size = size + enemy.size;
                SetSize();
                if (agentsHolder != null && enemy.agentsHolder != null)
                {
                    EnemyMode[] modes = enemy.agentsHolder.GetComponentsInChildren<EnemyMode>();
                    EnemyMovment[] enemyMovments = enemy.bubbleMovement.GetComponents<EnemyMovment>();
                    if (modes != null)
                    {
                        Debug.Log(modes.Length);
                        foreach (EnemyMode mode in modes)
                        {
                            Debug.Log(mode, mode);
                            mode.transform.SetParent(agentsHolder, true);
                        }
                        WishedDirectionHandler wishedDirectionHandler = bubbleMovement.GetComponent<WishedDirectionHandler>();
                        for (int i = 0; i < enemyMovments.Length; i++)
                        {
                            var newMove = bubbleMovement.transform.AddComponent<EnemyMovment>();
                            newMove.weigth = enemyMovments[i].weigth;
                            newMove.counterpart = enemyMovments[i].counterpart;
                            newMove.wishedDirection = wishedDirectionHandler;
                        }
                    }
                }
                Destroy(other.transform.parent.parent.gameObject);
            }
        }
    }

    public void SetSize()
    {
        if (bubbleMovement) { bubbleMovement.size = size; }
        Vector3 scale = Vector3.one * Mathf.Pow(size, 0.3333f);
        transform.localScale = scale;
        eatObject.localScale = scale * 0.7f;
    }

    private void OnDestroy()
    {
        popped?.Invoke();
    }
}
