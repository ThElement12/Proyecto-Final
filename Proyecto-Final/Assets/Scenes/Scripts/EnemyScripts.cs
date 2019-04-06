using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    public float life = 100;
    public float attackDamage = 1;
    public Vector3 attackPosition;

    Transform Target;
    //Vector3 position;
    float speed = 2;
    float step;
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        step = speed * Time.deltaTime;
        if(transform.position != attackPosition)
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);


    }
}
