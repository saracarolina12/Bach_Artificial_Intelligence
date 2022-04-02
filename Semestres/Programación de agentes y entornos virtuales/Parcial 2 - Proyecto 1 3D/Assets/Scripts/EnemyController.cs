using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    public float enemy_speed = 0.2f;
    private int hitpoints = 3;
    private Color[] cols = { Color.yellow, Color.green };
    public AudioClip clip;
    public GameObject effect;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(player.transform);
        GetComponent<Rigidbody>().velocity = (player.transform.position - transform.position) * enemy_speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(clip, player.transform.position);
            hitpoints--;
            if (hitpoints <= 0)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Renderer>().material.SetColor("_Color", cols[hitpoints - 1]);
            }
        }
    }
}
