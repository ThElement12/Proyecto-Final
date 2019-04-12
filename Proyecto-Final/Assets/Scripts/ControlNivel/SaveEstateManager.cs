using Assets.Scripts.Class;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class SaveEstateManager : MonoBehaviour
{
    static string RutaXML;
    public static PlayerStats CurrentGame;
    public static bool Guardado;
    public static bool Cargado;
    static TextMesh Continue;
    // Start is called before the first frame update
    void Start()
    {
        CurrentGame = new PlayerStats();
        RutaXML = Application.persistentDataPath + "/Ninja.xml";
         CurrentGame.UserName = ControlJuego.UserName;
        CurrentGame.NivelesLogrados = ControlJuego.NivelesPorDificultad;
        CurrentGame.Inventario = ControlJuego.Inventario;
        CurrentGame.Monedas = ControlJuego.money;
        Guardado = false;
        Cargado = false;
    }
   
    
    public static void SaveState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(PlayerStats));
        using(FileStream fstream = new FileStream(RutaXML, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream,CurrentGame);
        }
    }
    public static void LoadState()
    {
        Continue = GameObject.Find("Continuar").GetComponent<TextMesh>();

        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(PlayerStats));
        try
        {
            using(FileStream fstream = new FileStream(RutaXML, FileMode.Open))
            {

                CurrentGame = (PlayerStats)dcSerializer.ReadObject(fstream);
                ControlJuego.UserName = CurrentGame.UserName;
                ControlJuego.NivelesPorDificultad = CurrentGame.NivelesLogrados;
                ControlJuego.Inventario = CurrentGame.Inventario;
                ControlJuego.money = CurrentGame.Monedas;

            }
            Continue.gameObject.GetComponent<BoxCollider>().enabled = true;
            Continue.color = new Color(164, 33, 33,255);
        }
        catch (FileNotFoundException)
        {
            Continue.gameObject.GetComponent<BoxCollider>().enabled = false;
            Continue.color = new Color(194, 194, 194, 255);

            
        }

    }
  
}
