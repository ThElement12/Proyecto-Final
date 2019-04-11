using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroParabolico : MonoBehaviour
{
    Vector3 posicion = Vector3.zero;
    Vector3 velocidad = new Vector3(10,0);

    public float damage;
    Vector3 distancia;

    GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        distancia = jugador.transform.position - transform.position;


        //   angulo = Vector3.Angle(jugador.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       
        posicion.x = distancia.normalized.x * velocidad.x * Time.deltaTime;
        posicion.y = (velocidad.y * Time.deltaTime) + Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2);
        transform.Translate(posicion);
        velocidad += Physics.gravity * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<CharacterMovement>().RecibirDamage(damage);
            Destroy(gameObject);
        }
        else if(other.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
