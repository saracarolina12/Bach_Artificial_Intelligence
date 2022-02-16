using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject cosa;
    void OnTriggerEnter2D(Collider2D other){
        cosa.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D other){
        cosa.SetActive(true);
    }
}
