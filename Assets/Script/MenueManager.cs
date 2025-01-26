using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MenueManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject name;
    public GameObject menue;
    public GameObject restart;
    public GameObject start;
    bool ispaused = true;
    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!ispaused)
            {
                Pause();
            }
            else if (ispaused)
            {
                UnPause();
            }
        }
    }
    public void Pause()
    {
        ispaused = true;
        //cam1.enabled = true;
        //cam2.enabled = false;
         //GetComponent<CinemachineVirtualCamera>().Priority = -100;
        name.SetActive(true);
        menue.SetActive(true);
        restart.SetActive(true);
        start.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void UnPause()
    {
        ispaused = false;
        cam1.gameObject.SetActive(false);
        name.SetActive(false);
        menue.SetActive(false);
        //cam1.enabled = false;
        //cam2.enabled = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
