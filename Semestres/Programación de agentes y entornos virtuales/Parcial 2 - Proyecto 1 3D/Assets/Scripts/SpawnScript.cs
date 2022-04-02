using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject prefabEnemy;

    void Start()
    {
        InvokeRepeating("Generate", 0, 3);
    }

    void Generate()
    {
        Instantiate(prefabEnemy, transform);
    }

}
