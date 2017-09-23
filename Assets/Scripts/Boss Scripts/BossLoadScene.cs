using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLoadScene : MonoBehaviour
{

    BossAI bossAI;

    void Start()
    {
        bossAI = GetComponent<BossAI>();
    }

    void Update()
    {
        if (!bossAI.alive)
        {
            Invoke("ReturnLevelSelection", 2.0f);
        }
    }

    void ReturnLevelSelection()
    {
        LevelManager.esteLevelManager.LoadLevel("LevelSelection");

    }

}
