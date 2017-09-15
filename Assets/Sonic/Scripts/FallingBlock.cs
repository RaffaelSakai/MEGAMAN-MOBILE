using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
   [SerializeField]
    Rigidbody2D rdb;


  
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        //rdb.constraints = RigidbodyConstraints2D.FreezeRotation| RigidbodyConstraints2D.FreezePositionY;
        setRigidbodys_standStill();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Invoke("setRigidbodys_startFalling", 0.75f);
            //rdb.bodyType = RigidbodyType2D.Dynamic;

        }

        if (col.gameObject.tag == "Block")
        {
            Destroy(this.gameObject);

        }
    }


    public void setRigidbodys_standStill()
    {
        rdb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
    } 


    public void setRigidbodys_startFalling()
    {
        rdb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
