using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueManager : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject name;
    public GameObject menue;
    public GameObject restart;
    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        name.SetActive(true);
        menue.SetActive(true);
        restart.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        cam1.enabled = false;
        cam2.enabled = true;
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
