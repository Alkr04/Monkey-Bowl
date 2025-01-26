using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] GameObject g;

    static Counter instance;
    static public Counter Instance {  get { return instance; } }

    int num = 0;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
    }

    private void Start()
    {
        CheckCount();
    }


    public void SetCount(int i)
    {
        num = i;
        CheckCount();
    }

    private void CheckCount()
    {
        g.SetActive(num > 0);
    }
}
