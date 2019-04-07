using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    
    public GameObject BigEnemy, NormalEnemy;
    public bool isGenerating = false;
    bool isFight;
    int EnemyCount = 7;
    GameObject actualwall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGenerating == true)
        {
            Invoke("enemyInstance", 1);
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
        if(EnemyCount < 3)
        {
            Instantiate(BigEnemy, new Vector3(transform.position.x + 1, transform.position.y + 1), Quaternion.identity);
        }

        else
        {
            Instantiate(NormalEnemy, new Vector3(transform.position.x + 1, transform.position.y + 1), Quaternion.identity);
        }
        EnemyCount--;
    }
}
