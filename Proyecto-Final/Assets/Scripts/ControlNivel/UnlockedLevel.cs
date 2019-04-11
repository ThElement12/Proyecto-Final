using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedLevel : MonoBehaviour
{
    //level = NivelesLogrados - 1
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        if (ControlJuego.NivelesLogrados > level)
        {
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
