using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public Vector3 velocidad = new Vector3(8f,0);
    Transform Jugador;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        if(tag == "FireBall")
        {
            Jugador = GameObject.FindGameObjectWithTag("Player").transform;
            if (Jugador.rotation.y < 0)
            {
             GetComponent<SpriteRenderer>().flipX = true;
             velocidad *= -1;
            }
            Damage = CharacterMovement.attackDamage * 2;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(tag == "FireBall")
        {
            if(other.tag != "Player")
            {
                if(other.gameObject.GetComponent<EnemyScripts>() != null)
                {
                   other.gameObject.GetComponent<EnemyScripts>().life = Mathf.Clamp(other.gameObject.GetComponent<EnemyScripts>().life - Damage,0,100);
                   Destroy(gameObject);
                }
                
                
            }            
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
