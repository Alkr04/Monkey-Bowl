using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] float timeToRestart;
    Animator animator;

    public bool over = false;

    static DeathZone instance;
    public static DeathZone Instance { get { return instance; } }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.transform.parent.gameObject);
        if (collision.gameObject.GetComponent<PlayerMovement>() == null) { return; } 
        GameOver();
    }

    public void GameOver()
    {
        if (over || this == null) { return; }
        over = true;
        animator.Play("Fade");
        SoundHolder.Instance.PlaySound(SoundHolder.soundCatagory.drain, transform.position, true);

        StartCoroutine(Restart(timeToRestart));
    }

    IEnumerator Restart(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
