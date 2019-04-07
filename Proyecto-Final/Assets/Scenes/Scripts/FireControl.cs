using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public Vector3 velocidad = new Vector3(8f,0);
    SpriteRenderer Jugador;

    // Start is called before the first frame update
    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        if (Jugador.flipX)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            velocidad *= -1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            ///Quitarle vida al enemigo
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
