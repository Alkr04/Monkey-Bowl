using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMode : MonoBehaviour
{
    //statemashine

    public List<EnemyModeBase> list;
    public EnemyModeBase mode;
    [SerializeField] int curentMode = 0;

    private void Awake()
    {
        mode = list[curentMode];
    }

    private void Update()
    {
        mode.phase();
    }
}
