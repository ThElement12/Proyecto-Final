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
    public static bool Guardado = false;
    public static bool Cargado = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentGame = new PlayerStats();
        RutaXML = Application.persistentDataPath + "/Ninja";
        CurrentGame.UserName = ControlJuego.UserName;
        CurrentGame.NivelesLogrados = ControlJuego.NivelesLogrados;
        CurrentGame.Inventario = ControlJuego.Inventario;
    }

    // Update is called once per frame
    void Update()
    {
        
        
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
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(PlayerStats));
        try
        {
            using(FileStream fstream = new FileStream(RutaXML, FileMode.Open))
            {
                CurrentGame = (PlayerStats)dcSerializer.ReadObject(fstream);
            }
        }
        catch (FileNotFoundException)
        {

            throw;
        }

    }
  
}
