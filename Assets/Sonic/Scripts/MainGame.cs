using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainGame : MonoBehaviour {
    public static MainGame instance;//criação do singleton

    public Text ringTex;
    public Text timeTex;
    public Text livesTex;

	// Use this for initialization
	void Start () {

        if (instance == null)//checa se é unico
        {
            instance = this;//anexacao da referencia
        }

        else
        {
            Debug.LogError("Tem outro Maingame na cena");
        }

	}
    public void setRing(int rings)
    {
        ringTex.text = rings.ToString("Rings     000");
    
    }
    public void setLives(int lives)
    {
        livesTex.text = ("Lives x" + lives);

        

    }

    public void setTime(int time)
    {
        timeTex.text = time.ToString("Time : 00:00:00");

    }
}
