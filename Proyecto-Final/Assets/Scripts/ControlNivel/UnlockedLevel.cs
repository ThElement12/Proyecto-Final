using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedLevel : MonoBehaviour
{
   
    public int level;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (ControlJuego.NivelesPorDificultad[ControlJuego.indiceNivelActual] > level)
        {
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(true);

        }

    }
}
