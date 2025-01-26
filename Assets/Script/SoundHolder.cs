using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHolder : MonoBehaviour
{
    public enum soundCatagory
    {
        pop,
        bounce,
        step,
        bumper,
        drain,
        win
    }
    [SerializeField] AudioClip[] pop;
    [SerializeField] AudioClip[] bounce;
    [SerializeField] AudioClip[] step;
    [SerializeField] AudioClip bumper;
    [SerializeField] AudioClip drain;
    [SerializeField] AudioClip win;

    [SerializeField] AudioSource effects;
    [SerializeField] Transform oneShot;
    [SerializeField] float pitchVariance;

    static SoundHolder instance;
    public static SoundHolder Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(this.gameObject); }
        else { Destroy(this.gameObject); }
    }

    public void PlaySound(soundCatagory catagory, Vector3 position, bool randomPitch)
    {
        if (randomPitch) { effects.pitch = 1 - pitchVariance / 2 + Random.Range(-pitchVariance, pitchVariance); }
        else { effects.pitch = 1; }
        oneShot.position = position;
        AudioClip clip;
        float volume = 1;
        switch (catagory)
        {
            case soundCatagory.pop:
                clip = pop[Random.Range(0, pop.Length)];
                break;
            case soundCatagory.bounce:
                clip = bounce[Random.Range(0, bounce.Length)];
                volume = 1.3f;
                break;
            case soundCatagory.step:
                clip = step[Random.Range(0, step.Length)];
                break;
            case soundCatagory.bumper:
                clip = bumper;
                break;
            case soundCatagory.drain:
                clip = drain;
                break;
            case soundCatagory.win:
                clip = win;
                volume = 0.2f;
                break;
            default:
                clip = pop[0];
                break;
        }
        effects.PlayOneShot(clip, volume);
    }
}
