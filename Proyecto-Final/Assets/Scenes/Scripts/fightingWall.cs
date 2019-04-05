using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingWall : MonoBehaviour
{
    public static bool inFight = false;
    public bool fightnotOver = true;

    private void OnTriggerExit(Collider other)
    {
        if(tag == "wallEnter" && fightnotOver)
        {
            if(other.gameObject.tag == "Player")
            {
                inFight = true;
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
        if (tag == "wallEnter" && Input.GetKeyDown(KeyCode.RightArrow))
        {
            other.gameObject.GetComponent<CharacterMovement>().noCollision = false;
        }

        else if (tag == "wallExit" && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            other.gameObject.GetComponent<CharacterMovement>().noCollision = false;
        }
    }
}
