using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingWall : MonoBehaviour
{
    public static bool inFight = false;
    public bool fightnotOver = true;
    public static GameObject wall;
    

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") == null && GameObject.FindGameObjectWithTag("BigEnemy") == null)
        {
            inFight = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(tag == "wallEnter" && fightnotOver)
        {
            if(other.gameObject.tag == "Player")
            {
                wall = gameObject;
                inFight = true;
                for(int i= 0; i < 2;i++)
                {
                    wall.transform.GetChild(i).GetComponent<EnemyGen>().isGenerating = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inFight)
        {
            other.gameObject.GetComponent<CharacterMovement>().noCollision = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            if ((tag == "wallEnter" || tag == "firstWall") && Input.GetKeyDown(KeyCode.RightArrow))
            {
                other.gameObject.GetComponent<CharacterMovement>().noCollision = false;
            }

            else if ((tag == "wallExit" || tag == "lastWall") && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                other.gameObject.GetComponent<CharacterMovement>().noCollision = false;
            }
        }
    }
}
