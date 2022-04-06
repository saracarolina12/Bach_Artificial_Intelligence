using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControllers control;
    PlayerControllers.GameplayActions actions;
    private Vector2 moveVector;
    private Vector2 mouseVector;
    private Rigidbody rb;
	private Transform camT;
    public float force = 10f;
    public float sensibility = 0.1f;
    private void Awake() { 
        control = new PlayerControllers();
        actions = control.Gameplay;
        rb = GetComponent<Rigidbody>();
        camT = transform.GetChild(0);
		
		actions.MoveCamera.performed += ctx => mouseVector = ctx.ReadValue<Vector2>();
        actions.
        Movement.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
    }
    private void OnEnable() { 
        control.Enable();
    }
    private void OnDestroy() { 
        control.Disable();
    }
    private void Update() { 
        transform.Rotate( 0f, mouseVector.x * sensibility ,0f);
		camT.Rotate( -mouseVector.y * sensibility ,0f, 0f);	
        rb.AddForce(((transform.forward * moveVector.y) + (transform.right * moveVector.x)) * force);
    }
}