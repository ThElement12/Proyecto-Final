using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject background;
    public float backgroundsize;
    public float parallaxSpeed;

    Vector3 aceleration = new Vector3(0, Physics.gravity.y);
    Vector3 normalSpeed = Vector3.zero;
    bool isOnPlatform = false;
    Vector3 position;
    Transform cameraTransform;
    Transform[] layers;
    int rightIndex, leftIndex;
    float viewZone = 10, lastCameraX;
    

    // Start is called before the first frame update
    void Start()
    {

        cameraTransform = GameObject.Find("Main Camera").transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[background.transform.childCount];
        for (int i = 0; i < background.transform.childCount; i++)
            layers[i] = background.transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;
        normalSpeed.x = 5;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;

        background.transform.position += Vector3.right * (deltaX * parallaxSpeed);

        lastCameraX = cameraTransform.position.x;

        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
        {
            ScrollLeft();
        }

        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            ScrollRight();
        }

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

    private void ScrollLeft()
    {
        int LastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundsize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundsize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
    
}
