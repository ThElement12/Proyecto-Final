using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMoney : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ControlJuego.money++;
            Destroy(gameObject);
        }
    }
}
