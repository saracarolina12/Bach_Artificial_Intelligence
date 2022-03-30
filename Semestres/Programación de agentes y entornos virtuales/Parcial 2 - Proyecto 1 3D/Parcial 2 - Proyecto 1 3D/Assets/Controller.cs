using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float a = 50f;
    public float force = 10f;
    private Transform camT;
    private Rigidbody rb;

    void Start()
    {
        camT = transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float vRot = Input.GetAxis("Mouse Y") * a;
        float hRot = Input.GetAxis("Mouse X") * a;
        print(vRot + "," + hRot);

        float vax = Input.GetAxis("Vertical");
        float hax = Input.GetAxis("Horizontal");

        transform.Rotate(0f, hRot * Time.deltaTime, 0f);
        camT.Rotate(vRot * Time.deltaTime, 0f, 0f);

        rb.AddForce(((transform.forward * vax) + (transform.right * hax)) * force);
    }
}
