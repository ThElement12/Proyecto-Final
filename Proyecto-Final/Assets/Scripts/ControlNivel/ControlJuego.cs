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
        Nivel1,
        Nivel2,
        Nivel3,
        BossFinal
    }
   
    public enum GameState
    {
        SelectingLevel,
        LevelSelect,
        Playing,
        LevelPass
    }

    public static List<Items> Inventario = new List<Items> { new Items("Armadura", 0), new Items("Pocion", 0), new Items("Lagrima", 0), new Items("Amuleto", 0) };


    public static int money;
    public static GameState state;
    public static NivelActual Nivel;
    public static int NivelesLogrados = 4, level = 1;
    bool Pass = false;
    
    float playerLife;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        Nivel = NivelActual.Nivel1;
        state = GameState.SelectingLevel;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
           
            case GameState.LevelSelect:
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
                    
                    
                    break;
            case GameState.Playing:
                //playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().Vida;
                if (player.GetComponent<CharacterMovement>().Vida <= 0)
                {
                    state = GameState.LevelSelect;
                    SceneManager.LoadScene("MapaPrincipal");
                }
                break;
            case GameState.LevelPass:
                NivelesLogrados++;
                state = GameState.SelectingLevel;
                SceneManager.LoadScene("MapaPrincipal");
                break;
        }
                    
           

    }
    
}
