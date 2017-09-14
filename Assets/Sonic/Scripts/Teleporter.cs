using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{

    public string levelLoad;
    public bool LevelEnd = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (LevelEnd == true)
        {

            if (col.tag == "Player")
            {
                SceneManager.LoadScene(levelLoad);

            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (Input.GetButtonDown("Vertical"))
            {
                SceneManager.LoadScene(levelLoad);
            }
        }

    }
}
