using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        switch (name)
        {
            case "Nivel 1":
                ControlJuego.Nivel = ControlJuego.NivelActual.Nivel1;
                   
                break;
            case "Nivel 2":
                if (!transform.GetChild(1).GetComponent<SpriteRenderer>().enabled)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel2;
                }
                break;
            case "Nivel 3":
                if (!transform.GetChild(1).GetComponent<SpriteRenderer>().enabled)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel3;
                }
                break;
            case "Nivel 4":
                if (!transform.GetChild(1).GetComponent<SpriteRenderer>().enabled)
                {
                    ControlJuego.Nivel = ControlJuego.NivelActual.BossFinal;
                }
                break;
            case "Tienda":
                SceneManager.LoadScene("Tienda");
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
