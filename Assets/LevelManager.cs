using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public static LevelManager esteLevelManager;

    public bool autoLoad;
    public string LevelToLoad;

    //private void Awake()
    //{
    //    if(esteLevelManager == null)
    //    {
    //        esteLevelManager = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}


    // Use this for initialization
    void Start()
    {
        if (autoLoad)
            Invoke("LoadLevel", 3);

    }




    void LoadLevel()
    {
        PersistentData.NextLevel = LevelToLoad;
        SceneManager.LoadScene("Load");
    }

    public void LoadLevel(string levelName)
    {
        PersistentData.NextLevel = levelName;
        SceneManager.LoadScene("Load");
    }


    public void Quit()
    {
        Application.Quit();
    }

}
