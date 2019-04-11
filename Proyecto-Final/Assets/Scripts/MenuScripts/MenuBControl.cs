using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBControl : MonoBehaviour
{
    const float SCALEFACTOR = 1.2f;
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void OnMouseEnter()
    {
        _audioManager.PlayHoverSound();
        gameObject.transform.localScale *= SCALEFACTOR;
    }

    private void OnMouseExit()
    {
        //_audioManager.PlayExitSound();
        gameObject.transform.localScale /= SCALEFACTOR;
    }

    private void OnMouseUp()
    {
        _audioManager.PlayClickedSound();
        switch (gameObject.name)
        {
            case"Play":
                SceneManager.LoadScene("MapaPrincipal");
                break;
            case "Options":
                break;
            case "Credits":
                SceneManager.LoadScene("Credits");
                break;
            case "Quit":
                Application.Quit(0);
                break;
        }
    }
}
