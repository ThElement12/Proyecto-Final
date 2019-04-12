using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    public void SaveChange()
    {
        ControlJuego.UserName = GameObject.Find("Ruta").GetComponent<Text>().text;
        AudioManager.play = GameObject.Find("Music").GetComponent<Toggle>().isOn;
        Options.showCanvas(false);
        Options.Items1.SetActive(true);
    }
}
