using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsUsage : MonoBehaviour
{
    GameObject item;
    GameObject player;
    int power;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            item = GameObject.Find("Item2");
            if (item.GetComponent<SpriteRenderer>().sprite.name == "item2")
            {
                ControlJuego.Inventario[2].Cantidad--; 
                player.GetComponent<CharacterMovement>().Vida += 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            item = GameObject.Find("Item3");
            if(item.GetComponent<SpriteRenderer>().sprite.name == "item3")
            {
                ControlJuego.Inventario[3].Cantidad--;
                power = Random.Range(0, 3);
                switch (power)
                {
                    case 0:
                        if (player.GetComponent<CharacterMovement>().Vida < 50)
                        {
                            player.GetComponent<CharacterMovement>().Vida += 50;
                        }
                        break;
                    case 1:
                        player.GetComponent<CharacterMovement>().Armor += 5;
                        break;
                    case 2:
                        player.GetComponent<CharacterMovement>().attackDamage += 20;
                        break;
                }
            }
        }
    }
}
