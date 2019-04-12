using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STL1 : MonoBehaviour
{
    Vector3 position = Vector3.zero;
    float speed = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        position.y = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(position);
    }

    private void OnBecameInvisible()
    {
        switch (name)
        {
            case "Credits":
                SceneManager.LoadScene("MenuPrincipal");
                break;
            case "myStory1":
                SceneManager.LoadScene("Principal");
                break;
        }
    }
}
