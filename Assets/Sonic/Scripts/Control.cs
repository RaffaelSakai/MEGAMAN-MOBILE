using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    SpriteControl move;

    float InputHorizontal;

    // Update is called once per frame
    void Update()
    {

        move.SetVelocity(Input.GetAxis("Horizontal"));
        move.SetVelocity(InputHorizontal);
        if (Input.GetButtonDown("Jump"))
        {
            move.SetJump();
        }
    }


    public void GoRight()
    {
        InputHorizontal = 1;
    }
    public void GoLeft()
    {
        InputHorizontal = -1;
    }

    public void GoNeutral()
    {
        InputHorizontal = 0;
    }

    public void Jumpo()
    {
        move.SetJump();
    }
}




