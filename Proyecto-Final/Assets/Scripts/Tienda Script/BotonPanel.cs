using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPanel : MonoBehaviour
{
    public Sprite Presionado;
    public Sprite Soltado;

    private void OnMouseDown()
    {
        if(name == "BotonComprar")
        {
            GetComponent<SpriteRenderer>().sprite = Presionado;
        }
    }
    private void OnMouseUp()
    {
        if(name == "BotonComprar")
        {
            GetComponent<SpriteRenderer>().sprite = Soltado;
            ///Descontar dinero
            ///Agregar a los items 
        }
        transform.parent.gameObject.SetActive(false);

    }
}
