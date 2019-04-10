using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    GameObject player, newEnemy;
    public GameObject BigEnemy, NormalEnemy,FlyingEnemy, RangeEnemy;
    public bool isGenerating = false;
    bool isFight;
    int EnemyCount = 9;
    GameObject actualwall;
    int count = 30;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGenerating == true && EnemyCount > 0)
        {
            if (count == 0)
            {
                count = 50;
                enemyInstance();
            }
            else
                count--;
            //Invoke("enemyInstance", 0.5f);
            //EnemyCount--;
        }
        else
            return;
    }

    private void enemyInstance()
    {
        if(EnemyCount == 0)
        {
            isGenerating = false;
        }
        else if(EnemyCount > 5)
        {
            newEnemy = Instantiate(NormalEnemy, new Vector3(transform.position.x + 1, NormalEnemy.transform.position.y, -7), Quaternion.identity);
        }

        else if(EnemyCount > 3)
        {
            newEnemy = Instantiate(BigEnemy, new Vector3(transform.position.x + 1, BigEnemy.transform.position.y, -7), Quaternion.identity);
        }
        else if(EnemyCount > 1)
        {
            newEnemy = Instantiate(RangeEnemy, new Vector3(transform.position.x + 1, RangeEnemy.transform.position.y, -7), Quaternion.identity);

        }
        else
        {
            newEnemy = Instantiate(FlyingEnemy, new Vector3(transform.position.x + 1, FlyingEnemy.transform.position.y, -7), Quaternion.identity);
        }
        EnemyCount--;
    }
}
