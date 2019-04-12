﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFightScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("BigEnemy") == null)
        {
            ControlJuego.state = ControlJuego.GameState.LevelSelect;
            ControlJuego.Nivel = ControlJuego.NivelActual.Nivel0;
            SceneManager.LoadScene("MapaPrincipal");
        }
    }
}