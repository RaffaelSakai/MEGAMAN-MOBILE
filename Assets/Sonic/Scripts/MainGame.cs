using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainGame : MonoBehaviour
{
    public static MainGame instance;//criação do singleton

    public Text ringTex;
    public Text timeTex;
    public Text livesTex;


    public Transform fallPosition;
    public SpriteControl spriteControl;


    public GameObject[] flyingGrounds;
    public List<Vector3> posicoes;
    void Start()
    {

        if (instance == null)//checa se é unico
        {
            instance = this;//anexacao da referencia
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Tem outro Maingame na cena");
        }

        SetArray();
        posicoes = new List<Vector3>();

        for (int i = 0; i < flyingGrounds.Length; i++)
        {
            posicoes.Add(flyingGrounds[i].transform.position);
        }

        fallPosition = GameObject.Find("Limite Y").transform;
        spriteControl = GameObject.Find("Sonic").GetComponent<SpriteControl>();

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

    private void Update()
    {
        if (posicaoPlayer.y <= fallPosition.position.y)
        {
            CanFollowPlayer = false;
            Invoke("RespawnPlayer", 2);
        }
        else
            CanFollowPlayer = true;

    }


    bool CanFollowPlayer
    {
        //get { return Camera.main.GetComponent<CameraSonic>().canFollow; }
        set { Camera.main.GetComponent<CameraSonic>().canFollow = value; }
    }

    Vector3 posicaoPlayer
    {
        get { return GameObject.Find("Sonic").GetComponent<Transform>().position; }
    }

    void RespawnPlayer()
    {
        spriteControl.DoTheRespawn();
        resetPositions();
    }

    void resetPositions()
    {
        for (int i = 0; i < flyingGrounds.Length; i++)
        {
            flyingGrounds[i].transform.position = posicoes[i];
            flyingGrounds[i].GetComponent<FallingBlock>().setRigidbodys_standStill();
        }
    }

    void SetArray()
    {
        flyingGrounds = GameObject.FindGameObjectsWithTag("FlyingGround");
    }
}
