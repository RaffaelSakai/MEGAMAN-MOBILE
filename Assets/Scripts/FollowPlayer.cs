using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform player;
    public float altura;

    void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }


    void Update()
    {
        if (player)
            transform.position = new Vector3(player.position.x, player.position.y + altura, transform.position.z);
    }
}
