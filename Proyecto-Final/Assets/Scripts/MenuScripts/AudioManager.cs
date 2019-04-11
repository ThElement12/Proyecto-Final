using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource HoverSound, ClickSound;


    public void PlayHoverSound()
    {
        HoverSound.Play();
    }

    public void PlayClickedSound()
    {
        ClickSound.Play();
    }
  
}
