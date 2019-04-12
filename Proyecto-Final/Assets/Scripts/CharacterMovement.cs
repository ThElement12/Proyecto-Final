using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool noCollision = false;
    public static float attackDamage = 10;
    public GameObject Fuego;

   
    Vector3 jumpforce;
    Vector3 aceleration = new Vector3(0.1f,Physics.gravity.x);
    Vector3 normalSpeed = Vector3.zero;
    bool isOnPlatform = false;
    Vector3 position;
    int jump = 1;
    Animator _Animator;

    public float Vida = 100;
    public float DamageReceived = 0;
    public float Armor = 5;

    
    float SkillTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        normalSpeed.x = 5;
        position = Vector3.zero;
        _Animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {


        if (!noCollision)
        {

            if (Input.GetAxis("Horizontal") != 0)
            {
                normalSpeed.x = aceleration.x;    
            } 
            else
                normalSpeed.x = 0;

            position.x = normalSpeed.x;


            if (Input.GetAxis("Horizontal") != 0)
                _Animator.SetBool("isRunning", true);
            
           else
                _Animator.SetBool("isRunning", false);
            
           if(Input.GetAxis("Horizontal") < 0)
                transform.rotation = new Quaternion(0, -179.99f, 0, 0);
          
           else if(Input.GetAxis("Horizontal") > 0)
                transform.rotation = new Quaternion(0, 0, 0, 0);
          
        }
        else 
        {
            normalSpeed.x = 0;
            position.x = 0;
        }

        if (!isOnPlatform)
        {
            _Animator.SetBool("isJumping", true);
            position.y = normalSpeed.y * Time.deltaTime + aceleration.y * (Mathf.Pow(Time.deltaTime, 2));

            normalSpeed.y += aceleration.y * Time.deltaTime;
        }
        else
        {   normalSpeed.y = 0;
            _Animator.SetBool("isJumping", false);
        }
            
       
        if (Input.GetKey(KeyCode.X))
            _Animator.SetBool("isAttacking", true);
        
        else
           _Animator.SetBool("isAttacking", false);
        
        if (Input.GetKey(KeyCode.C) && SkillTime <= 0 && ControlJuego.Inventario.Find(x=> x.Nombre == "Amuleto").Cantidad == 1)
        {
            SkillTime = 3;
            _Animator.SetBool("isJutsing", true);
            Invoke("Instance", 0.35f);
            
            
        }
        else
            _Animator.SetBool("isJutsing", false);
        


        if (Input.GetButtonDown("Jump") && jump == 1)
        {
            jump = 0;
            isOnPlatform = false;
            normalSpeed.y = 9.8f;
            aceleration.y = Physics.gravity.y;
        }

        Camera.main.transform.position = new Vector3(transform.position.x,Camera.main.transform.position.y, Camera.main.transform.position.z);
        transform.Translate(position);
        SkillTime -= Time.deltaTime;
        
    }
    void Instance()
    {
        Instantiate(Fuego, new Vector3(GetComponent<SpriteRenderer>().flipX ? transform.position.x - 0.44f : transform.position.x + 0.44f,
            transform.position.y,transform.position.z), Quaternion.identity);
    }
    public void RecibirDamage(float damage)
    {
        Vida -= Mathf.Clamp(damage - (damage * 0.02f * Armor), 0, Vida);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            position.y = 0;
            normalSpeed.y = 0;
            aceleration.y = 0;
            isOnPlatform = true;
            jump = 1;
        }
        if(other.tag == "Weapon")
        {
           DamageReceived = other.gameObject.transform.parent.GetComponent<EnemyScripts>().attackDamage;
           RecibirDamage(DamageReceived);
         
        }
    }
    
}
