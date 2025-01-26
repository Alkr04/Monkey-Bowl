using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueManager : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }

}
