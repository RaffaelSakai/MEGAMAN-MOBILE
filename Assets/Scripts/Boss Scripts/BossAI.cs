using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { IdleState, WalkState, PunchState }

public class BossAI : MonoBehaviour
{

    public BossState EstadoBoss;

    Collider2D _collider;
    [SerializeField]
    Sprite[] IdleArray, WalkArray, PunchArray;
    public int SpeedChangeIdle, speedChangeWalk, SpeedChangePunch;
    float Index;
    public float velocidade;
    SpriteRenderer sR;

    public int valorAleatorio;
    [SerializeField]
    Collider2D hitBox;


    public bool canFire;

    public int healthValue;
    public bool alive;

    [SerializeField]
    Color regularColor, damageColor;



    void Start()
    {

        AIStart();
    }

    void Update()
    {
        alive = healthValue > 0 ? true : false;
        if (alive)
        {
            AIUpdate();
            //print(valorAleatorio);
        }
        else
        {
            Invoke("Die", 1);
        }
    }


    void Die()
    {
        Color tmp = sR.color;
        //tmp.a = 0f;
        tmp.a = Mathf.Lerp(tmp.a, 0f, Time.deltaTime);
        sR.color = tmp;
        _collider.enabled = false;
       // Destroy(gameObject);

    }

    void AIStart()
    {
        _collider = GetComponent<Collider2D>();
        sR = GetComponent<SpriteRenderer>();
        EstadoBoss = BossState.IdleState;
        SetSprites();
        Index = 0;
        alive = true;
        //valorAleatorio = Random.Range(0, 2);
        valorAleatorio = 1;
        setHitBox();
        sR.color = regularColor;
    }

    void AIUpdate()
    {
        if (Encounter)
        {
            alive = healthValue > 0 ? true : false;
            if (alive)
            {
                Vector3 direcao = transform.position - PlayerTransform.position;
                CheckForDistance(direcao);
                SwitchState();
                UpdateRandomCount();
                ColliderControl();
            }
        }
    }

    void SwitchState()
    {
        switch (EstadoBoss)
        {
            case BossState.IdleState:
                AnimationState(IdleArray, 4f);
                canFire = true;
                break;
            case BossState.PunchState:
                AnimationState(PunchArray, 4f);
                canFire = false;
                break;
            case BossState.WalkState:
                AnimationState(WalkArray, 4f);
                canFire = true;
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
            valorAleatorio = ++valorAleatorio % 2;

        }

    }

    void CheckForDistance(Vector3 direcao)
    {
        float _distancia = direcao.magnitude;
        if (_distancia <= 2)
        {
            EstadoBoss = BossState.PunchState;
        }
        else
        {
            if (valorAleatorio == 0)
            {
                EstadoBoss = BossState.IdleState;
                CheckForDirection(direcao, false);
            }
            else
            {
                EstadoBoss = BossState.WalkState;
                CheckForDirection(direcao, true);
            }

        }
    }

    void CheckForDirection(Vector3 direcao, bool canWalk)
    {

        if (direcao.x < 0)//esta a esquerda do player
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (canWalk)
                mover(true);
        }
        else if (direcao.x > 0)//esta a direita do player
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (canWalk)
                mover(false);
        }
    }

    void AnimationState(Sprite[] Sprites, float spriteSpeedChange)
    {
        float addValue = Time.deltaTime * spriteSpeedChange;
        Index += addValue;

        Index = Index > Sprites.Length ? 0 : Index;
        sR.sprite = Sprites[(int)Index];

    }

    void ColliderControl()
    {
        if (EstadoBoss == BossState.PunchState)
        {
            if ((int)Index == 2)
            {
                hitBox.enabled = true;
            }
            else
            {
                hitBox.enabled = false;
            }

        }
        else
        {

            hitBox.enabled = false;
        }
    }

    void SetSprites()
    {
        IdleArray = SpriteManager.CarregaSprite("Boss/Idle");
        WalkArray = SpriteManager.CarregaSprite("Boss/Walk");
        PunchArray = SpriteManager.CarregaSprite("Boss/Hit");
    }

    void mover(bool invertido)
    {
        Vector3 move = new Vector3(velocidade, 0, 0);
        if (!invertido)
        {
            transform.position -= move;
        }
        else
        {
            transform.position += move;
        }
    }

    void setHitBox()
    {
        Transform[] Children = GetComponentsInChildren<Transform>();
        foreach (Transform tr in Children)
        {
            if (tr != gameObject.transform)
            {
                if (tr.GetComponent<Collider2D>())
                {
                    hitBox = tr.GetComponent<Collider2D>();
                    break;
                }
            }
        }

        hitBox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<BulletBaseClass>())
        {
            healthValue -= col.gameObject.GetComponent<BulletBaseClass>().dano;
            sR.color = damageColor;
            Invoke("ResetColor", 0.5f);
        }
    }

    public Transform PlayerTransform
    {
        get { return GameObject.Find("AlvoZero").GetComponent<Transform>(); }
    }

    bool Encounter
    {
        get { return GameObject.Find("Porta").GetComponent<PortaHabilita>().inside; }
    }

    void ResetColor()
    {
        sR.color = regularColor;
    }

}
