using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject plate;

    void OnTriggerEnter2D(Collider2D other)
    {
        plate.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        plate.SetActive(true);
    }
}
