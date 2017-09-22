using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionFase : MonoBehaviour
{
    public string path;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("TrocaCena", 2);
        }
    }


    void TrocaCena()
    {
        PersistentData.LevelsPassed += 1;
        LevelManager.esteLevelManager.LoadLevel("LevelSelection");
        // SceneManager.LoadScene(path);

    }

}
