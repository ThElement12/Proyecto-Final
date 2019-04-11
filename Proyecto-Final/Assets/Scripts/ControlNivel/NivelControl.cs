using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(name == "Nivel 1" || !transform.GetChild(1).GetComponent<SpriteRenderer>().enabled)
        {
            switch (name)
            {
                case "Nivel 1":
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel1;
                   
                    break;
                case "Nivel 2":
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel2;
                    Debug.Log("Carga");
                    break;
                case "Nivel 3":
                    ControlJuego.Nivel = ControlJuego.NivelActual.Nivel3;
                    Debug.Log("Carga");
                    break;
                case "Nivel 4":
                    ControlJuego.Nivel = ControlJuego.NivelActual.BossFinal;
                    Debug.Log("Carga");
                    break;
                default:
                    break;
            }
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
