using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordKill : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        player.GetComponent<Animator>().SetBool("isAttacking", false);
        player.GetComponent<Animator>().SetBool("isRunning", true);
    }
}
