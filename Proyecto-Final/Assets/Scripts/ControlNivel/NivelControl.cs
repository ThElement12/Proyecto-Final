using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelControl : MonoBehaviour
{
    int level;
    // Start is called before the first frame update
    void Start()
    {
        if(name != "Nivel 1" && name != "Tienda")
            level = GetComponent<UnlockedLevel>().level;
    }
    
    private void OnMouseUp()
    {
        switch (name)
        {
            case "Nivel 1":
                ControlJuego.Nivel = ControlJuego.NivelActual.Nivel1;
                ControlJuego.state = ControlJuego.GameState.LevelSelect;
                   
                break;
            case "Nivel 2":
                if (ControlJuego.NivelesLogrados > level)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel2;
                    ControlJuego.state = ControlJuego.GameState.LevelSelect;
                }
                break;
            case "Nivel 3":
                if (ControlJuego.NivelesLogrados > level)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel3;
                    ControlJuego.state = ControlJuego.GameState.LevelSelect;
                }
                break;
            case "Nivel 4":
                if (ControlJuego.NivelesLogrados > level)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.BossFinal;
                    ControlJuego.state = ControlJuego.GameState.LevelSelect;
                }
                break;
            case "Tienda":
                SceneManager.LoadScene("Tienda");
                break;
            case "Dificultad":

                break;
            default:
                break;
        }
        
    }
    private void OnMouseEnter()
    {
        transform.localScale *= 1.2f;
    }
    private void OnMouseExit()
    {
        transform.localScale /= 1.2f;
        
    }

}
