using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Class;

public class InventoryMaker : MonoBehaviour
{
    public GameObject pocion, amuleto, armadura, lagrima;
    
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (ControlJuego.Inventario[i].Nombre == "Pocion" && ControlJuego.Inventario[i].Cantidad > 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = pocion.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
            else if (ControlJuego.Inventario[i].Nombre == "Armadura" && ControlJuego.Inventario[i].Cantidad > 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = armadura.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
            else if (ControlJuego.Inventario[i].Nombre == "Amuleto" && ControlJuego.Inventario[i].Cantidad > 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = amuleto.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
            else if (ControlJuego.Inventario[i].Nombre == "Lagrima" && ControlJuego.Inventario[i].Cantidad > 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = lagrima.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < /*transform.childCount*/4; i++)
        {
            if (ControlJuego.Inventario[i].Nombre == "Pocion" && ControlJuego.Inventario[i].Cantidad >= 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = pocion.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
            else if (ControlJuego.Inventario[i].Nombre == "Armadura" && ControlJuego.Inventario[i].Cantidad >= 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = armadura.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
            else if (ControlJuego.Inventario[i].Nombre == "Amuleto" && ControlJuego.Inventario[i].Cantidad >= 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = amuleto.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
            else if (ControlJuego.Inventario[i].Nombre == "Lagrima" && ControlJuego.Inventario[i].Cantidad >= 0)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = lagrima.GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMesh>().text = ControlJuego.Inventario[i].Cantidad.ToString();
            }
        }
    }
}
