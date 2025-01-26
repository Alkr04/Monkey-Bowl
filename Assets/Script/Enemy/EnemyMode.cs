using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMode : MonoBehaviour
{
    //statemashine
    [SerializeField] int minTime = 10;
    [SerializeField] int maxTime = 20;
    public List<EnemyModeBase> list;
    public EnemyModeBase mode;
    [SerializeField] int curentMode = 0;

    private void Awake()
    {
        mode = list[curentMode = Random.Range(0, list.Count)];
        StartCoroutine(timer());
    }

    private void Update()
    {
        mode.phase();
    }

    IEnumerator timer()
    {
        float time = 1;
        while (true)
        {
            time = Random.Range(minTime, maxTime);

            yield return new WaitForSeconds(time);
            curentMode = Random.Range(0, list.Count);
            mode = list[curentMode % list.Count];

        }
    }
}
