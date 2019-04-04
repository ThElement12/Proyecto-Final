using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 aceleration = new Vector3(0, Physics.gravity.y);
    Vector3 normalSpeed = Vector3.zero;
    bool isOnPlatform = false;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed.x = 5;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = Input.GetAxis("Horizontal") * normalSpeed.x;
        if (!isOnPlatform)
        {
            position.y += normalSpeed.y * Time.deltaTime + (aceleration.y * Mathf.Pow(Time.deltaTime, 2)) / 2;
            normalSpeed.y = normalSpeed.y + aceleration.y * Time.deltaTime;
        }
        position *= Time.deltaTime;
        transform.Translate(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform")
        {
            normalSpeed.y = 0;
            aceleration.y = 0;
            isOnPlatform = true;
        }
    }
}
