using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STL1 : MonoBehaviour
{
    Vector3 position = Vector3.zero;
    float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        position.y = speed * Time.deltaTime;//:v feliz cabron 
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(position);
        if (transform.position.y > 14.79f)
            SceneManager.LoadScene("Principal");
            

    }
}
