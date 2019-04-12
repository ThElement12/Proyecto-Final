using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource HoverSound, ClickSound, Fondo;
    public static bool play = true;

    void Awake()
    {
        /*if(play)
            GetComponent<AudioSource>().playOnAwake = true;*/
    }

    private void Update()
    {
        if (!Fondo.isPlaying && play)
        {
            Fondo.Play();
        }
        else if(Fondo.isPlaying && !play)
        {
            Fondo.Stop();
        }
    }
    public void MusicOff()
    {
        if (!play)
            Fondo.Stop();
        else
            Fondo.Play();
    }

    public void PlayHoverSound()
    {
        if(play)
            HoverSound.Play();
    }

    public void PlayClickedSound()
    {
        if(play)
            ClickSound.Play();
    }
  
}
