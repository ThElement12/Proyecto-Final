using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPanel : MonoBehaviour
{
    public Sprite Presionado;
    public Sprite Soltado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
