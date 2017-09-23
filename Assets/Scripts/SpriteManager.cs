using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteManager : MonoBehaviour
{
    public static Sprite[] CarregaSprite(string str)
    {
        Sprite[]arraySprite = Resources.LoadAll<Sprite>(str);
        return arraySprite;
    }
}
