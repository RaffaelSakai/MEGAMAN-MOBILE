using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public TextMesh percentual;
    public GameObject barra;
    AsyncOperation load;
    float percentualNum = 0;

    void Start()
    {
        load = SceneManager.LoadSceneAsync(PersistentData.NextLevel);
        load.allowSceneActivation = false;
    }


    void Update()
    {
        percentualNum = Mathf.MoveTowards(percentualNum, load.progress, Time.deltaTime);

        percentual.text = ((percentualNum * 100) + 10).ToString("00.0") + "%";

        if (percentualNum > 0.89f)
        {
            //print("Done");
            load.allowSceneActivation = true;
        }

        barra.transform.localScale = new Vector3(percentualNum*3, 1, 1);
    }
}
