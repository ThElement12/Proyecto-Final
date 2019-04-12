using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMenu : MonoBehaviour
{
    Animator animator;
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("BigEnemy");
        //animator.SetBool("isRunning", true);
        if (enemy != null)
        {
            if (enemy.transform.position.x < -3)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", true);
            }
        }
    }
}
