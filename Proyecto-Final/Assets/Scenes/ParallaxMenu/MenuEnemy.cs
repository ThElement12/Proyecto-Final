using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnemy : MonoBehaviour
{
    public GameObject Enemy;
    int count = 100;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Enemy, new Vector3(10.94f, -0.9360749f, -2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("BigEnemy") == null)
        {
            if (count == 0)
                Instantiate(Enemy, new Vector3(10.94f, -0.9360749f, -2), Quaternion.identity);
            else
                count--;
        }
        else
            count = 100;

    }
}
