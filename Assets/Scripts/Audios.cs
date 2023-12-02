using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public static Audios Instance;
     AudioSource adioSou;
    public AudioClip win;
    public AudioClip loss;
    public AudioClip right;
    private void Awake()
    {
        Ins();


    }
    private void Start()
    {
        adioSou = GetComponent<AudioSource>();
    }
    public void Win()
    {
        adioSou.clip = win;
        adioSou.Play();
    }
    public void Loss()
    {
        adioSou.clip = loss;
        adioSou.Play();
    }
    public void Right()
    {
        adioSou.clip = right;
        adioSou.Play();
    }
    void Ins()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
