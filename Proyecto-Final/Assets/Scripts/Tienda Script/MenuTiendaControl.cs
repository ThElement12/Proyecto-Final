using Assets.Scripts.Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTiendaControl : MonoBehaviour
{
    public static TextMesh Wallet;
    public int cost;
    public TextMesh costTxt; 
    TextMesh info;
    GameObject PanelCompra;
    public static string ItemSeleccion;
    // Start is called before the first frame update

    private void Awake()
    {
        Wallet = GameObject.Find("Wallet").GetComponent<TextMesh>();
        Wallet.text = ControlJuego.money.ToString();
        PanelCompra = GameObject.FindGameObjectWithTag("PanelCompra");
        info = GameObject.Find("Info").GetComponent<TextMesh>();
    }
    void Start()
    {
        PanelCompra.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "Armadura")
        {

            PanelCompra.SetActive(true);
            PanelCompra.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            info.text = "Incrementa la armadura base en +5.\n Se compra una vez";
            costTxt.text = cost.ToString();
        }
        else if (gameObject.name == "Pocion")
        {
            PanelCompra.SetActive(true);
            PanelCompra.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            info.text = "Restaura un 10% de la vida actual.\n Solo se puede llevar un maximo de 3";
            costTxt.text = cost.ToString();
        }
        else if (gameObject.name == "Lagrima")
        {
            PanelCompra.SetActive(true);
            PanelCompra.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            info.text = "Lagrima misteriosa. Sus beneficios son desconocidos.\n Dicen que proviene de una Diosa.\n Se compra una vez";
            costTxt.text = cost.ToString();
        }
        else if (gameObject.name == "Amuleto")
        {
            PanelCompra.SetActive(true);
            PanelCompra.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            info.text = "Increible amuleto, permite manejar el elemento fuego.\n Se compra una vez";
            costTxt.text = cost.ToString();
        }
        else
        {
            SceneManager.LoadScene("MapaPrincipal");
        }
        if(cost > ControlJuego.money)
            costTxt.color = new Color(255, 0, 0);
        //else
        //    costTxt.color = new Color(255, 255,255);


        ItemSeleccion = name;
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
