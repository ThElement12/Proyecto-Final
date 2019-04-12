using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelControl : MonoBehaviour
{
    int level;
    GameObject PanelDificultad, PanelSalir, AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
        if(name == "Dificultad")
        {
            PanelDificultad = GameObject.Find("PanelDificultad");
            PanelDificultad.SetActive(false);

        }
        else if(name == "Salir")
        {
            PanelSalir = GameObject.Find("PanelSalir");
            PanelSalir.SetActive(false);

        }
        else if (name != "Nivel 1" && name != "Tienda")
           level = GetComponent<UnlockedLevel>().level;
        
    }
    private void OnMouseDown()
    {
        AudioManager.GetComponent<AudioManager>().PlayClickedSound();
    }
    private void OnMouseUp()
    {
        switch (name)
        {
            case "Tienda":
                SceneManager.LoadScene("Tienda");
                break;
            case "Dificultad":
                PanelDificultad.SetActive(true);
                break;
            case "Salir":
                PanelSalir.SetActive(true);
                break;

            default:
                SwitchNivel();
                break;
        }
        
    }
    private void OnMouseEnter()
    {
        AudioManager.GetComponent<AudioManager>().PlayHoverSound();
        
        transform.localScale *= 1.2f;
    }
    private void OnMouseExit()
    {
        transform.localScale /= 1.2f;
        
    }
    void SwitchNivel()
    {
        switch (name)
        {
            case "Nivel 1":
                ControlJuego.Nivel = ControlJuego.NivelActual.Nivel1;
                ControlJuego.state = ControlJuego.GameState.LevelSelect;

                break;
            case "Nivel 2":
                if (ControlJuego.NivelesPorDificultad[ControlJuego.indiceNivelActual] > level)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel2;
                    ControlJuego.state = ControlJuego.GameState.LevelSelect;
                }
                break;
            case "Nivel 3":
                if (ControlJuego.NivelesPorDificultad[ControlJuego.indiceNivelActual] > level)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel3;
                    ControlJuego.state = ControlJuego.GameState.LevelSelect;
                }
                break;
            case "Nivel 4":
                if (ControlJuego.NivelesPorDificultad[ControlJuego.indiceNivelActual] > level)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.BossFinal;
                    ControlJuego.state = ControlJuego.GameState.LevelSelect;
                }
                break;
        }

        }

}
