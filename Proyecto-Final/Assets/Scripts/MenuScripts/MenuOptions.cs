using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    
    public void SaveChange()
    {
        GameObject Texto = GameObject.Find("Info");
        
        if (Directory.Exists(GameObject.Find("Ruta").GetComponent<Text>().text) || GameObject.Find("Ruta").GetComponent<Text>().text.ToString() == "")
        {
            ControlJuego.Ruta = GameObject.Find("Ruta").GetComponent<Text>().text;
            AudioManager.play = GameObject.Find("Music").GetComponent<Toggle>().isOn;
            Options.showCanvas(false);
            Options.Items1.SetActive(true);
        }
        else
        {
            Texto.GetComponent<Text>().text = "La ruta no existe";
        }


    }
}
