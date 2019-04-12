using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource HoverSound, ClickSound, Fondo;
    public static bool play = true;


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
