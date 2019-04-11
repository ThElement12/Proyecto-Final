using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    GameObject player, newEnemy;
    public GameObject BigEnemy, NormalEnemy,FlyingEnemy, RangeEnemy;
    public bool isGenerating = false;
    bool isFight;
    int normalEnemyC = 3, bigEnemyC = 1, flyingEnemyC = 2, rangeEnemyC = 1, EnemyCount;

    GameObject actualwall;
    int count = 30;
    // Start is called before the first frame update
    void Start()
    {
        bigEnemyC = Mathf.RoundToInt(bigEnemyC * ControlJuego.NivelesLogrados / 2) < 1 ? 1 : Mathf.RoundToInt(bigEnemyC * ControlJuego.NivelesLogrados / 2);
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyCount = normalEnemyC + bigEnemyC + flyingEnemyC + rangeEnemyC;
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
        else if(normalEnemyC > 0)
        {
            newEnemy = Instantiate(NormalEnemy, new Vector3(transform.position.x + 1, NormalEnemy.transform.position.y, -7), Quaternion.identity);
            normalEnemyC--;
        }

        if(bigEnemyC > 0 && normalEnemyC == 0 && rangeEnemyC == 0 && flyingEnemyC == 0)
        {
            newEnemy = Instantiate(BigEnemy, new Vector3(transform.position.x + 1, BigEnemy.transform.position.y, -7), Quaternion.identity);
            bigEnemyC--;
        }
        if(rangeEnemyC > 0 && normalEnemyC == 0)
        {
            newEnemy = Instantiate(RangeEnemy, new Vector3(transform.position.x + 1, RangeEnemy.transform.position.y, -7), Quaternion.identity);
            rangeEnemyC--;
        }
        if(flyingEnemyC > 0 && normalEnemyC == 0 && rangeEnemyC == 0)
        {
            newEnemy = Instantiate(FlyingEnemy, new Vector3(transform.position.x + 1, FlyingEnemy.transform.position.y, -7), Quaternion.identity);
            flyingEnemyC--;
        }
        EnemyCount--;
    }
}
