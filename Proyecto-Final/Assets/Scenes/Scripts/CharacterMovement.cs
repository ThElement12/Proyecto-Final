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


    Animator _Animator;


    bool isAttacking = false;
    bool isJumping = false;
    bool isRunning = false;
    bool isJutsing = false;


    // Start is called before the first frame update
    void Start()
    {
        normalSpeed.x = 5;
        position = transform.position;
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!noCollision)
        {
           position.x = Input.GetAxis("Horizontal") * normalSpeed.x;
           if(Input.GetAxis("Horizontal") != 0)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }
            

        if (!isOnPlatform)
        {
            isJumping = true;
            position.y = normalSpeed.y * Time.deltaTime + aceleration.y * (Mathf.Pow(Time.deltaTime, 2) / 2);
            normalSpeed.y += aceleration.y * Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
        position *= Time.deltaTime;
        if (Input.GetKey(KeyCode.X))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        if (Input.GetKey(KeyCode.C))
        {
            isJutsing = true;
        }
        else
        {
            isJutsing = false;
        }


        if (Input.GetButtonDown("Jump") && jump == 1)
        {
            jump = 0;
            isOnPlatform = false;
            normalSpeed.y = 170;
            aceleration.y = Physics.gravity.y;
        }

        _Animator.SetBool("isAttacking", isAttacking);
        _Animator.SetBool("isJumping", isJumping);
        _Animator.SetBool("isRunning", isRunning);
        transform.Translate(position);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            normalSpeed.y = 0;
            aceleration.y = 0;
            isOnPlatform = true;
            jump = 1;
        }
    }
}
