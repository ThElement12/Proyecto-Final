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
    public static NivelActual Nivel;
    public static int NivelesLogrados = 0;
    List<GameObject> Niveles;
    // Start is called before the first frame update
    void Start()
    {
        Nivel = NivelActual.Nivel1;
        Niveles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Nivel"));
        Niveles = Niveles.OrderBy(o => o.name).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MapaPrincipal")
        {
            if (NivelesLogrados < 4 && NivelesLogrados > 1)
            {
                for (int i = 1; i <= NivelesLogrados; i++)
                {
                    Niveles[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                    Niveles[i].transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }
}
