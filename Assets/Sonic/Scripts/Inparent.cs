using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inparent : MonoBehaviour {



    Rigidbody2D player;
    void Update()
    {
        if (player)
        {
            player.velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print(col.gameObject.tag);
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponent<Rigidbody2D>();
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (player)
        {

            player = null;
        }

    }
}
