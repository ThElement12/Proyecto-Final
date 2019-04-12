using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    //public GameObject myChild;
    public float speed;
    Vector3 position = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        position.x = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(position);
        if(transform.position.x <= -myChild.transform.position.x)
        {
            Instantiate(myChild);
            Destroy(gameObject);
        }
    }
}
