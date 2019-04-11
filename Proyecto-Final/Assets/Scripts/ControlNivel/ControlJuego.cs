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
    public static int NivelesLogrados = 0, level = 1;
    List<GameObject> Niveles;
    // Start is called before the first frame update
    void Start()
    {
        Nivel = NivelActual.Nivel1;
        Niveles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Nivel"));
        Niveles = Niveles.OrderBy(o => o.name).ToList();
        state = GameState.SelectingLevel;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
           
            case GameState.LevelSelect:
                    
                        if (NivelesLogrados < 4 && NivelesLogrados > 1)
                        {
                            for (int i = 1; i <= NivelesLogrados; i++)
                            {
                                Niveles[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                                Niveles[i].transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                            }
                        }
                        switch (Nivel)
                        {
                            case NivelActual.Nivel1:
                                SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            case NivelActual.Nivel2:
                                SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            case NivelActual.Nivel3:
                                SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            case NivelActual.BossFinal:
                                SceneManager.LoadScene("Principal");
                                ///Dificultad
                                break;
                            default:
                                break;
                        }
                    
                    state = GameState.Playing;
                    break;
            case GameState.Playing:
                
                break;
            case GameState.LevelPass:
                level++;
                //NivelesLogrados++;
                state = GameState.SelectingLevel;
                SceneManager.LoadScene("MapaPrincipal");
                break;
        }
                    
           

    }
    
}
