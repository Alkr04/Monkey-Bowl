using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public Dictionary <GameObject, byte> eateble = new ();
    public GameObject[] game;

    // Start is called before the first frame update
    void Start()
    {
        notDestroy();
        game = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < game.Length; i++)
        {
            //Debug.Log(eateble);
            eateble.Add(game[i],1);
            //Debug.Log(eateble.Count);
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
