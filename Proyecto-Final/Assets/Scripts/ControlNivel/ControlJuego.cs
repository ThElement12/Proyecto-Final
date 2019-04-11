using Assets.Scripts.Class;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
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
    public static int NivelesLogrados = 5, level = 1;
    bool Pass = false;
    GameObject[] Niveles;
    float playerLife;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        Nivel = NivelActual.Nivel1;
        Niveles = new GameObject[4];
        Niveles = GameObject.FindGameObjectsWithTag("Nivel");
        state = GameState.SelectingLevel;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
           
            case GameState.LevelSelect:
                    
                        /*if (NivelesLogrados < 4 && NivelesLogrados > 1)
                        {
                            for (int i = 1; i <= NivelesLogrados; i++)
                            {
                                
                                Niveles[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                                Niveles[i].transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                            }
                        }*/
                        /*if(NivelesLogrados > 1)
                        {
                            for(int i = 0; i < NivelesLogrados; i++)
                            {
                                
                            }
                        }*/
                        switch (Nivel)
                        {
                            case NivelActual.Nivel1:
                                level = 1;
                                if (!Pass)
                                {
                                    Pass = true;
                                    SceneManager.LoadScene("Intro");
                                }
                                else
                                    SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            case NivelActual.Nivel2:
                                level = 2;
                                SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            case NivelActual.Nivel3:
                                level = 3;
                                SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            case NivelActual.BossFinal:
                                level = 4;
                                SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            default:
                                break;
                        }
                    
                    state = GameState.Playing;
                    break;
            case GameState.Playing:
                playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().Vida;
                if (playerLife <= 0)
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
