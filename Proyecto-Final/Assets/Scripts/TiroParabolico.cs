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
        
        

     //   angulo = Vector3.Angle(jugador.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distancia = jugador.transform.position - transform.position;
        posicion.x = distancia.normalized.x * velocidad.x * Time.deltaTime;
        posicion.y = (velocidad.y * Time.deltaTime) + Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2);

//     transform.LookAt(jugador.transform);
        transform.Translate(posicion);
        velocidad += Physics.gravity * Time.deltaTime;

        //  posicion.x = velocidad.x * Time.deltaTime;

        //angulo = Mathf.Atan(distancia.y / distancia.x) * Mathf.Rad2Deg;
        //posicion.x = velocidad.x / Time.deltaTime;
        // posicion.y = velocidad.y * Mathf.Cos(angulo * Mathf.Deg2Rad) * Time.deltaTime + 0.5f * Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2);

        //velocidad.y += Physics.gravity.y * Time.deltaTime;
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
