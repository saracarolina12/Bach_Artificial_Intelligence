//BLUE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerRed : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float movementX;
    private float movementY;
    public float speed = 2;
    public Transform fireP;
    public GameObject bulletP;
    public float bulletForce = 20, bulletLife;
    private float nextShoot;
    private InputAction fireOn; //
    private PlayerInput m_PlayerInput;//
    public bool RedPlayer;
    private float timer = 0.0f;
    private GameObject Newbull, Oldbull;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //nextShoot = 0;
    }

    private void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        

        if(movementY<0 && !(movementX<0 && movementY<0) && !(movementY<0 && movementX>0) ){ //DOWN
            animator.SetInteger("direction", 0);
        }
        if(movementX>0 && movementY<0){ //RIGHT DOWN
            animator.SetInteger("direction", 1);
        }
        if(movementX>0 && !(movementY<0 && movementX>0) && !(movementX>0 && movementY>0)){ //RIGHT
            animator.SetInteger("direction", 2);
        }
        if(movementX>0 && movementY>0){ //RIGHT UP
            animator.SetInteger("direction", 3);
        }
        if(movementY>0 && !(movementX>0 && movementY>0) && !(movementX<0 && movementY>0)){ //UP
            animator.SetInteger("direction", 4);
        }
        if(movementX<0 && movementY>0){ //LEFT UP
            animator.SetInteger("direction", 5);
        }
        if(movementX<0 && !(movementX<0 && movementY<0) && !(movementX<0 && movementY>0)){ //LEFT
             animator.SetInteger("direction", 6);
        }
        if(movementX<0 && movementY<0){ //LEFT DOWN
            animator.SetInteger("direction", 7);
        }
        
        
    }

    void FixedUpdate(){
        Vector2 movement = new Vector2(movementX, movementY);
        rb.velocity = movement *  speed; 
    }


    void Shoot(){
        timer += Time.deltaTime;
        //int seconds = timer % 60;

        //Debug.Log(fireP.position);
       // Debug.Log("alive bull: ");    
        //Debug.Log(timer);
        Newbull = Instantiate(bulletP, fireP.position, fireP.rotation);
        //ameObject Newbull = Instantiate(bulletP, fireP.transform.position, fireP.transform.rotation);
        
        Rigidbody2D Srb = Newbull.GetComponent<Rigidbody2D>();
        //Rigidbody2D Srb = GameObject.Find("RedTank").GetComponent<BoxCollider2D>().isTrigger = true;
        //GameObject.Find("RedTank").GetComponent<EdgeCollider2D>().isTrigger = true;
        Srb.AddForce(fireP.up *bulletForce, ForceMode2D.Impulse);
        
        
        OnColliSionEnter2D(Newbull);
        Oldbull = Newbull;
    }
    void Update(){
       if(m_PlayerInput == null){
           m_PlayerInput = GetComponent<PlayerInput>();
           fireOn = m_PlayerInput.actions["fire"]; 
       }

       if(fireOn.triggered){
            Shoot();
            // timer += Time.deltaTime;
            // if(timer >= 2.0){
            //     Destroy(Oldbull, bulletLife);
            // }
       }

    }


    void OnColliSionEnter2D(Collision col){
        Debug.Log(col);
        // if (col.gameobject.tag == "Enemy"){
        //     Destroy(gameObject);
        // }
    }


}


