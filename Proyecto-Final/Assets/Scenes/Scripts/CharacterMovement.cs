using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool noCollision = false;
    Vector3 aceleration = new Vector3(0, Physics.gravity.y);
    Vector3 jumpforce;
    Vector3 normalSpeed = Vector3.zero;
    bool isOnPlatform = false;
    Vector3 position;
    int jump = 1;

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed.x = 5;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!noCollision)
            position.x = Input.GetAxis("Horizontal") * normalSpeed.x;

        if (!isOnPlatform)
        {
            position.y = normalSpeed.y * Time.deltaTime + aceleration.y * (Mathf.Pow(Time.deltaTime, 2) / 2);
            normalSpeed.y += aceleration.y * Time.deltaTime;
        }
        position *= Time.deltaTime;
        if (Input.GetButtonDown("Jump") && jump == 1)
        {
            jump = 0;
            isOnPlatform = false;
            normalSpeed.y = 170;
            aceleration.y = Physics.gravity.y;
        }
        transform.Translate(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform")
        {
            normalSpeed.y = 0;
            aceleration.y = 0;
            isOnPlatform = true;
            jump = 1;
        }
    }
}
