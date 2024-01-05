using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource audio;
    public Image soundOff;
    public Image soundOn;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audio.Play();
    }


    public void Sound()
    {
        if(AudioListener.volume == 1.0f)
        {
            AudioListener.volume = 0.0f;
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
        else
        {
            AudioListener.volume = 1.0f;
            soundOff.enabled = false;
            soundOn.enabled = true;
        }
        Debug.Log(AudioListener.volume);
    }
}
