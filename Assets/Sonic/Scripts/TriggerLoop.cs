using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoop : MonoBehaviour {
    public Collider2D actor1, actor2;
    bool wait = false;


    void OnTriggerEnter2D()
    {
        if(!wait)
        {
            wait =true;
        actor1.enabled = !actor1.enabled;
    
        actor2.enabled = !actor2.enabled;
        Invoke("reset",1);
        
        }
    }

    void reset()
    {
        wait = false;
    }


}

