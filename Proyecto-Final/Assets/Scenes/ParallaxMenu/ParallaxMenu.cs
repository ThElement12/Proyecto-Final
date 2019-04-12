using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    public GameObject myChild;
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
        switch (tag)
        {
            case "mountain1":
                if (transform.position.x <= -26.6f)
                {
                    Instantiate(myChild, new Vector3(26.6f, myChild.transform.position.y, myChild.transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
            case "mountain2":
                if (transform.position.x <= -34.71f)
                {
                    Instantiate(myChild, new Vector3(34.71f, myChild.transform.position.y, myChild.transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
            case "cloud":
                if (transform.position.x <= -25.6f)
                {
                    Instantiate(myChild, new Vector3(25.6f, myChild.transform.position.y, myChild.transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
            case "Platform":
                if (transform.position.x <= -33f)
                {
                    Instantiate(myChild, new Vector3(9f, myChild.transform.position.y, myChild.transform.position.z), Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
        }
        
    }
}
