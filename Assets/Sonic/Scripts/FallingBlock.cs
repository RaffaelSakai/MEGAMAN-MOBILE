using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rdb;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            rdb.bodyType = RigidbodyType2D.Dynamic;
           
        }

        if (col.gameObject.tag == "Block")
        {
            Destroy(this.gameObject);

        }
    }

   






}
