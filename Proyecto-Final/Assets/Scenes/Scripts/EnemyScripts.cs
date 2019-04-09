using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    public float life = 100;
    public float attackDamage = 1;
    public float attackDistance;
    public float speed;
    public float myAttackPos;

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
        if(transform.position.x - Target.transform.position.x < 0)
        {
            if (tag == "NormalEnemy")
                GetComponent<SpriteRenderer>().flipX = false;

            else  
                GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if (tag == "NormalEnemy")
                GetComponent<SpriteRenderer>().flipX = true;

            else
                GetComponent<SpriteRenderer>().flipX = false;
        }
        step = speed * Time.deltaTime;
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
        }

    }
}
