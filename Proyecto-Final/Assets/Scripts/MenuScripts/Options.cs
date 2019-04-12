using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    GameObject Canvas;
    public static GameObject Items1, Items2;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Canvas.SetActive(false);
        Items1 = GameObject.Find("MenuItems");
        Items2 = GameObject.Find("MenuItems2");

        Items2.SetActive(false);

    }

    public void getName()
    {
        //ControlKniveHit.playername = GameObject.Find("NameField").GetComponent<Text>().text;
        GameObject.Find("NameField").GetComponent<Text>().text = "";
        showCanvas(false);
        //MenuControl.IniciarOpciones(true);
    }

    public void showCanvas(bool isTrue = true)
    {
        Canvas.SetActive(isTrue);
    }
    

}
