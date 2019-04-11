﻿using Assets.Scripts.Class;
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
            if (int.Parse(GameObject.Find("Precio").GetComponent<TextMesh>().text) < ControlJuego.money)
            {
                if (MenuTiendaControl.ItemSeleccion != "Pocion")
                {
                    if (ControlJuego.Inventario.Find(x => x.Nombre == MenuTiendaControl.ItemSeleccion).Cantidad == 0)
                    {
                        ControlJuego.Inventario.Find(x => x.Nombre == MenuTiendaControl.ItemSeleccion).Cantidad++;
                    }

                }
                else
                {
                    if (ControlJuego.Inventario.Find(x => x.Nombre == MenuTiendaControl.ItemSeleccion).Cantidad < 3)
                    {
                        ControlJuego.Inventario.Find(x => x.Nombre == MenuTiendaControl.ItemSeleccion).Cantidad++;
                    }

                }
                GetComponent<SpriteRenderer>().sprite = Soltado;
                ControlJuego.money -= int.Parse(GameObject.Find("Precio").GetComponent<TextMesh>().text);
            }
            
        }
        transform.parent.gameObject.SetActive(false);

    }
}
