using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTiendaControl : MonoBehaviour
{
    TextMesh info;
    Vector3 PosicionInfo;
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("Info").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
       PosicionInfo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PosicionInfo.x += 0.5f;
        PosicionInfo.y += 0.1f;
        PosicionInfo.z = 0;
    }
    private void OnMouseOver()
    {
        if (gameObject.name == "Armadura")
        {
            info.gameObject.transform.position = PosicionInfo;
            info.text = "Incrementa la armadura base en +5";
            
        }
        else if(gameObject.name == "Pocion")
        {
            info.gameObject.transform.position = PosicionInfo;
            info.text = "Restaura un 10% de la vida actual";

        }
        else if(gameObject.name == "Lagrima")
        {
            info.gameObject.transform.position = PosicionInfo;
            info.text = "Lagrima misteriosa. Sus beneficios son desconocidos.\n Dicen que proviene de una Diosa";
        }
        else if(gameObject.name == "Amuleto")
        {
            info.gameObject.transform.position = PosicionInfo;
            info.text = "Increible amuleto, permite manejar el elemento fuego";

        }
        else
        {
            ///Salir
        }

    }
    private void OnMouseExit()
    {
        info.text = "";
    }
}
