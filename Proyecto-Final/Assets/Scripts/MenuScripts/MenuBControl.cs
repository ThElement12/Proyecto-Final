using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBControl : MonoBehaviour
{

    const float SCALEFACTOR = 1.2f;
    private AudioManager _audioManager;
    public static bool newGame = false;
   

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
                Options.Items2.SetActive(true);
                Options.Items1.SetActive(false);
                SaveEstateManager.LoadState();
                break;
            case "Nuevo Juego":
                ControlJuego.Reset();
                newGame = true;
                SceneManager.LoadScene("MapaPrincipal");
                break;
            case "Continuar":
                SaveEstateManager.LoadState();
                SceneManager.LoadScene("MapaPrincipal");
                break;
            case "Options":
                Options.Items2.SetActive(false);
                Options.Items1.SetActive(false);
                Options.showCanvas(true);
                break;
            case "Credits":
                SceneManager.LoadScene("Credits");
                break;
            case "Volver":
                Options.Items2.SetActive(false);
                Options.Items1.SetActive(true);
                break;
            case "Quit":
                Application.Quit(0);
                break;
        }
        gameObject.transform.localScale /= SCALEFACTOR;
    }
}
