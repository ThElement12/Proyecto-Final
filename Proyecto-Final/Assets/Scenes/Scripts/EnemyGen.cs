using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    GameObject player, newEnemy;
    public GameObject BigEnemy, NormalEnemy;
    public bool isGenerating = false;
    bool isFight;
    int EnemyCount = 7;
    GameObject actualwall;
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
            enemyInstance();
            //Invoke("enemyInstance", 0.5f);
            EnemyCount--;
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
        if(EnemyCount > 3)
        {
            newEnemy = Instantiate(NormalEnemy, new Vector3(transform.position.x + 1, NormalEnemy.transform.position.y + 1), Quaternion.identity);
        }

        else
        {
            newEnemy = Instantiate(BigEnemy, new Vector3(transform.position.x + 1, BigEnemy.transform.position.y + 1), Quaternion.identity);
        }
        
    }
}
