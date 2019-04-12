using Assets.Scripts.Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPanel : MonoBehaviour
{
    public Sprite Presionado;
    public Sprite Soltado;

    private void OnMouseDown()
    {
        if(name == "BotonComprar" || name == "Si" || name == "No")
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
                
                ControlJuego.money -= int.Parse(GameObject.Find("Precio").GetComponent<TextMesh>().text);
                MenuTiendaControl.Wallet.text = ControlJuego.money.ToString();
                transform.parent.gameObject.SetActive(false);
            }
            GetComponent<SpriteRenderer>().sprite = Soltado;

        }
        else if(name == "Si")
        {
            SaveEstateManager.SaveState();
            GetComponent<SpriteRenderer>().sprite = Soltado;
        }
        else if(name == "No")
        {
            transform.parent.gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = Soltado;
        }
        else
            transform.parent.gameObject.SetActive(false);





    }
}
