using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button botaoBossLevel; 

    void Start()
    {

    }

    void Update()
    {
        if (PersistentData.LevelsPassed >= 4)
        {
            botaoBossLevel.enabled = true;
        }else
        {
            botaoBossLevel.enabled = false;
        }
        
    }
}
