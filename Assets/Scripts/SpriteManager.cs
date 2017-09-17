using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteManager : MonoBehaviour
{

    

    #region Inutilizados
    /*
    void SetSpriteSonic()
    {
        SonicIdle = Resources.LoadAll<Sprite>("Sonic/Sonic Idle");
        SonicWalk = Resources.LoadAll<Sprite>("Sonic/Sonic Walk");
        SonicRun = Resources.LoadAll<Sprite>("Sonic/Sonic Run");
        SonicJump = Resources.LoadAll<Sprite>("Sonic/Sonic Jump");
    }

    void SetSpriteTails()
    {
        TailsIdle = Resources.LoadAll<Sprite>("Tails/Tails Idle");
        TailsWalk = Resources.LoadAll<Sprite>("Tails/Tails Walk");
        TailsRun = Resources.LoadAll<Sprite>("Tails/Tails Run");
        TailsJump = Resources.LoadAll<Sprite>("Tails/Tails Jump");
        TailsFly = Resources.LoadAll<Sprite>("Tails/Tails Fly");
    }
    */

    #endregion



    public static Sprite[] CarregaSprite(string str)
    {
        Sprite[]arraySprite = Resources.LoadAll<Sprite>(str);
        return arraySprite;
    }
}
