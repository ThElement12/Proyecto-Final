using Assets.Scripts.Class;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
    public GameObject player;
    public enum NivelActual
    {
        Nivel0,
        Nivel1,
        Nivel2,
        Nivel3,
        BossFinal
    }
    public enum DificultadActual
    {
        MuyFacil,//0
        Facil,//1
        Medio,//2
        Dificil//3
    }
   
    public enum GameState
    {
        LevelSelect,
        Playing,
        LevelPass
    }
    

    public static List<Items> Inventario = new List<Items> { new Items("Armadura", 0), new Items("Pocion", 0), new Items("Lagrima", 0), new Items("Amuleto", 0) };

    public static string UserName = "";
    public static int money;
    public static GameState state;
    public static DificultadActual Dificultad;
    public static NivelActual Nivel;
    public static int level = 1;
    public static List<int> NivelesPorDificultad = new List<int> { 0, 0, 0, 0 };
    public static bool Pass = false;
    
    float playerLife;
    public static int indiceNivelActual = 0;

    // Start is called before the first frame update
    void Start()
    {

        
        Dificultad = DificultadActual.MuyFacil;
        //player = GameObject.FindGameObjectWithTag("Player");
        //Nivel = NivelActual.Nivel1;
        if(SceneManager.GetActiveScene().name == "MapaPrincipal")
        {
            state = GameState.LevelSelect;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveEstateManager.Cargado)
        {
            Inventario = SaveEstateManager.CurrentGame.Inventario.ToList();
            NivelesPorDificultad = SaveEstateManager.CurrentGame.NivelesLogrados.ToList();
            SaveEstateManager.Cargado = false;


        }
        switch (state)
        {
            case GameState.LevelSelect:
                switch (Dificultad)
                {
                    case DificultadActual.MuyFacil:
                        SwitchDeNivel();
                        indiceNivelActual = 0;
                            CharacterMovement.attackDamage = 100;
                        
                        break;
                    case DificultadActual.Facil:
                        SwitchDeNivel();
                        indiceNivelActual = 1;
                            CharacterMovement.attackDamage = 75;
                        break;
                    case DificultadActual.Medio:
                        SwitchDeNivel();
                        indiceNivelActual = 2;
                            CharacterMovement.attackDamage = 50;
                        break;
                    case DificultadActual.Dificil:
                        SwitchDeNivel();
                        indiceNivelActual = 3;
                            CharacterMovement.attackDamage = 25;
                        break;
                    default:
                        break;
                }

                break;
            case GameState.Playing:
                if (player.GetComponent<CharacterMovement>().Vida <= 0)
                {
                    state = GameState.LevelSelect;
                    Nivel = NivelActual.Nivel0;
                    SceneManager.LoadScene("MapaPrincipal");
                }
                break;
            case GameState.LevelPass:

                NivelesPorDificultad[indiceNivelActual] = level + 1;
                state = GameState.LevelSelect;
                Nivel = NivelActual.Nivel0;
                SceneManager.LoadScene("MapaPrincipal");
                
                break;
            default:
                break;
        }
                    
           

    }
    void SwitchDeNivel()
    {
        switch (Nivel)
        {
            case NivelActual.Nivel1:
                state = GameState.Playing;
                level = 1;
                if (!Pass)
                {
                    Pass = true;
                    SceneManager.LoadScene("Intro");
                }
                else
                {
                    SceneManager.LoadScene("Principal");
                }
                ///Dificultad
                break;
            case NivelActual.Nivel2:
                level = 2;
                state = GameState.Playing;
                SceneManager.LoadScene("Principal");
                ///Dificultad
                break;
            case NivelActual.Nivel3:
                level = 3;
                state = GameState.Playing;
                SceneManager.LoadScene("Principal");
                ///Dificultad
                break;
            case NivelActual.BossFinal:
                level = 4;
                state = GameState.Playing;
                SceneManager.LoadScene("Principal");
                ///Dificultad
                break;
            default:
                break;
        }

    }
    public static void Reset()
    {
        Pass = false;
        UserName = "";
        NivelesPorDificultad = new List<int> { 0, 0, 0, 0 };
        Inventario = new List<Items> { new Items("Armadura", 0), new Items("Pocion", 0), new Items("Lagrima", 0), new Items("Amuleto", 0) };
        money = 0;
    }

}
