﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    FPSActions control;
    FPSActions.FPSMapActions actions;
    private Vector2 mouseVector, horVector;
    private Rigidbody rb;
    private Transform camT;
    public float sens = 0.1f;
    public float force = 3f;
    private bool jmp;
    public float jumpForce = 200f;

    private void Awake()
    {
        control = new FPSActions();
        actions = control.FPSMap;
        rb = GetComponent<Rigidbody>();
        camT = transform.GetChild(0); //transf. del primer hijo

        actions.MoveCamera.performed += ctx => mouseVector = ctx.ReadValue<Vector2>();
        actions.MoveHorizontal.performed += ctx => horVector = ctx.ReadValue<Vector2>();;
        actions.Jump.performed += ctx => jmp = true;
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDestroy()
    {
        control.Disable();
    }

    void Update()
    {
        transform.Rotate( 0f, mouseVector.x * sens, 0f );
        camT.Rotate( -mouseVector.y * sens, 0f, 0f );
        rb.AddForce( ((transform.forward * horVector.y) + (transform.right * horVector.x)) * force );
        if(jmp && rb.velocity.y == 0) rb.AddForce(transform.up * jumpForce);
        jmp = false;
    }
}
