using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    enum BossState { IdleState, WalkState, PunchState }
    BossState EstadoBoss;

    [SerializeField]
    Sprite[] IdleArray, WalkArray, PunchArray;
    public int SpeedChangeIdle, speedChangeWalk, SpeedChangePunch;
    float Index;

    SpriteRenderer sR;

    int valorAleatorio;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        EstadoBoss = BossState.IdleState;
        SetSprites();
        Index = 0;
        valorAleatorio = Random.Range(0, 4);
    }

    void Update()
    {
        Vector3 direcao = transform.position - PlayerTransform.position;
        float distancia = direcao.magnitude;

        CheckForDistance(distancia);
        AIUpdate();
        CheckDirection(direcao);
        UpdateRandomCount();

    }
    void AIUpdate()
    {
        switch (EstadoBoss)
        {
            case BossState.IdleState:
                AnimationState(IdleArray, 2f);
                break;
            case BossState.PunchState:
                AnimationState(PunchArray, 2f);
                break;
            case BossState.WalkState:
                AnimationState(WalkArray, 2f);
                break;
        }
    }

    float valorSoma = 0;
    void UpdateRandomCount()
    {
        valorSoma += Time.deltaTime;

        if (valorSoma >= 10)
        {
            valorSoma = 0;
            valorAleatorio = Random.Range(0, 4);
        }

    }

    void CheckForDistance(float _distancia)
    {
        if (_distancia <= 2)
        {
            EstadoBoss = BossState.PunchState;
        }
        else
        {
            if (valorAleatorio == 0 || valorAleatorio == 2)
            {
                EstadoBoss = BossState.IdleState;
            }
            else
            {
                EstadoBoss = BossState.WalkState;
            }
        }
    }

    void CheckDirection(Vector3 direcao)
    {

        
        if (direcao.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
           // print("player esta a direita do boss");
        }
        else if (direcao.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //print("player esta a esquerda do boss");
        }
    }

    void AnimationState(Sprite[] Sprites, float spriteSpeedChange)
    {
        float addValue = Time.deltaTime * spriteSpeedChange;
        Index += addValue;

        Index = Index > Sprites.Length ? 0 : Index;
        sR.sprite = Sprites[(int)Index];

    }

    void SetSprites()
    {
        IdleArray = SpriteManager.CarregaSprite("Boss/Idle");
        WalkArray = SpriteManager.CarregaSprite("Boss/Walk");
        PunchArray = SpriteManager.CarregaSprite("Boss/Hit");
    }

    Transform PlayerTransform
    {
        get { return GameObject.Find("Zero").transform; }
    }


}
