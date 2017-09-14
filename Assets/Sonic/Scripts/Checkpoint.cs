using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Sprite CheckpointOFF;
    public Sprite CheckpointON;

    private SpriteRenderer render;

    public bool checkpointActive ;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Sonic"))
        {
            render.sprite = CheckpointON;
            checkpointActive = true;
        }

       
    }
}
