using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Input System interpreta las teclas

public class Player : MonoBehaviour
{

    private Rigidbody2D rb; //apuntador
    private Animator animator;
    private float movementX;
    private float movementY;
    public float speed = 1;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();     //para acceder a las variables de animator
    }
    
    private void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        bool mov = true;

        if(movementX > 0) animator.SetInteger("direction", 1);
        if(movementX < 0) animator.SetInteger("direction", 3);
        if(movementY > 0) animator.SetInteger("direction", 2);
        if(movementY < 0) animator.SetInteger("direction", 0);
    
        if( !Keyboard.current.wKey.isPressed &&
            !Keyboard.current.aKey.isPressed &&
            !Keyboard.current.sKey.isPressed &&
            !Keyboard.current.dKey.isPressed )
            mov = false;
          
          animator.SetBool("walking", mov);
  
    }
    void FixedUpdate(){
        Vector2 movement = new Vector2(movementX, movementY);
        rb.velocity = movement*speed;
    }
}
