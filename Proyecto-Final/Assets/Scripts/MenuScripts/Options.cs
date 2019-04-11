using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Canvas.SetActive(false);

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
