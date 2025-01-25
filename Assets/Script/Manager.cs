using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public Dictionary <GameObject, byte> eateble;

    // Start is called before the first frame update
    void Start()
    {
        notDestroy();
        GameObject[] game = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < game.Length; i++)
        {
            eateble.Add(game[i],1);
        }
    }
    void notDestroy()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
