using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDificultad : MonoBehaviour
{

    GameObject Selector;
    // Start is called before the first frame update
    void Start()
    {
        Selector = GameObject.Find("Selector");
    }

    // Update is called once per frame
    
    private void OnMouseUp()
    {
        Selector.transform.position = new Vector3(Selector.transform.position.x, transform.position.y, Selector.transform.position.z);
        switch (name)
        {
            case "Muy Facil":
                ControlJuego.Dificultad = ControlJuego.DificultadActual.MuyFacil;
                break;
            case "Facil":
                ControlJuego.Dificultad = ControlJuego.DificultadActual.Facil;
                break;
            case "Medio":
                ControlJuego.Dificultad = ControlJuego.DificultadActual.Medio;
                break;
            case "Dificil":
                ControlJuego.Dificultad = ControlJuego.DificultadActual.Dificil;
                break;

            default:
                break;
        }
    }

}
