﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    public int CoinsCount;
    public float life = 100;
    public float attackDamage = 1;
   // public float attackDistance;
    public float speed;
    public float myAttackPos;
    public GameObject Fire, Coin;


    public bool Attack = false;
    
    float CoinPosition;
    int count = 40;
    Vector3 attackPosition;
    Transform Target;
    float step;
    private void Start()
    {
        attackPosition = new Vector3(myAttackPos, transform.position.y, transform.position.z);
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(life == 0)
        {
            if(tag == "Range Enemy" || tag == "NormalEnemy")
            {
                Attack = false;
                GetComponent<Animator>().SetBool("isDying", true);
                Destroy(gameObject, 1);
            }
            else
            {
                for(int i = 0; i < CoinsCount; i++)
                {
                    CoinPosition = Random.Range(-2, 2);
                    Instantiate(Coin, new Vector3(transform.position.x + CoinPosition, -8.6f, -7f), Quaternion.identity);
                }
                Destroy(gameObject);
            }

        }
        MovimientoEnemigo();
        AtaqueEnemigo();
    }

    void MovimientoEnemigo()
    {
        if (transform.position.x - Target.transform.position.x < 0)
        {
            if (tag == "NormalEnemy")

                transform.rotation = new Quaternion(0, 0, 0, 0);

            else
                transform.rotation = new Quaternion(0, -179.9f, 0, 0);
        }
        else
        {
            if (tag == "NormalEnemy")
                transform.rotation = new Quaternion(0, -179.9f, 0, 0);

            else
                transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        step = speed * Time.deltaTime;
        if(tag != "Flying Enemy" && tag != "Range Enemy")
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }


    }
    void AtaqueEnemigo()
    {
        
        if (transform.position.x - Target.transform.position.x > attackPosition.x || transform.position.x - Target.transform.position.x < -attackPosition.x)
        {
            transform.position = new Vector3(Vector3.MoveTowards(transform.position, Target.position, step).x, transform.position.y, transform.position.z);
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
        else if (transform.position.x - Target.transform.position.x <= attackPosition.x || transform.position.x - Target.transform.position.x >= -attackPosition.x)
        {
            if (count == 0)
            {
                count = 40;
                GetComponent<Animator>().SetBool("isAttacking", true);
            }

            else
            {
                count--;
                GetComponent<Animator>().SetBool("isAttacking", false);
            }

            if (tag == "Flying Enemy")
            {
                if (Attack && GameObject.FindGameObjectWithTag("Flying Enemy Fire") == null)
                {
                    Instantiate(Fire, new Vector3(transform.position.x + 0.2f, transform.position.y, -7), Quaternion.identity);
                    Fire.tag = gameObject.tag + " Fire";
                    Fire.GetComponent<TiroParabolico>().damage = attackDamage;
                    Attack = false;
                }
            }
            else if(tag == "Range Enemy")
            {
                if (Attack && GameObject.FindGameObjectWithTag("Range Enemy Fire") == null)
                {
                    Instantiate(Fire, new Vector3(transform.position.x + 0.2f, transform.position.y, -7), Quaternion.identity);
                    Fire.tag = gameObject.tag + " Fire";
                    Fire.GetComponent<TiroParabolico>().damage = attackDamage;
                    Attack = false;
                }

            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            life = Mathf.Clamp(life - CharacterMovement.attackDamage, 0, 100);
        }
        
    }
}
