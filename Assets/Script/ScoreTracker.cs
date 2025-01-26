using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] RectTransform winIndicator;
    [SerializeField, Range(0,1)] float winProcent = 0.8f;
    [SerializeField] float winTime;
    Animator animator;

    Slider slider;
    bool over = false;

    static ScoreTracker instance;
    public static ScoreTracker Instance { get { return instance; } }

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        animator = GetComponent<Animator>();

        if (instance == null) { instance = this; }
        else { Destroy(this); }

        winIndicator.anchorMax = new Vector2(winProcent, 0.5f);
        winIndicator.anchorMin = new Vector2(winProcent, 0.5f);
    }

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForEndOfFrame();
        slider.maxValue = Manager.Instance.Enemys.Count;
        slider.value = slider.maxValue;
    }

    public void EnemyDead()
    {
        if (DeathZone.Instance.over) { return; }
        slider.value--;
        if (slider.value / slider.maxValue < winProcent) 
        {
            if (over) { return; }
            over = true;
            DeathZone.Instance.over = true;
            animator.Play("Win");
            SoundHolder.Instance.PlaySound(SoundHolder.soundCatagory.win, transform.position, false);
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(winTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
