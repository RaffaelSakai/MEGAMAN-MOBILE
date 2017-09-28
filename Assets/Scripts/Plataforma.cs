using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{

    Rigidbody2D _rigidBody;
    float contador;
    bool colidiu;
    Vector3 posicaoInicial;
    SpriteRenderer sR;
    Collider2D _colider;

    void Start()
    {
        _colider = GetComponent<Collider2D>();
        sR = GetComponent<SpriteRenderer>();
        posicaoInicial = transform.position;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.gravityScale = 5;
        _rigidBody.mass = 200;
        contador = 0;
        colidiu = false;
    }


    void Update()
    {
        if (colidiu)
            StartCounting();
        else
        {
            SetConstrain1();
        }



    }

    void SetConstrain2()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }


    void SetConstrain1()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        Color tmp = sR.color;
        tmp.a = 1f;
        sR.color = tmp;
        _colider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform posicaoRelativa = collision.gameObject.transform.Find("AlvoZero");
            Vector3 calculoDiferenca = posicaoRelativa.position - transform.position;

            if (calculoDiferenca.y > 0)
            {
                colidiu = true;
            }
             
        }

        if (!collision.gameObject.CompareTag("Player") && !collision.collider.isTrigger)
        {
            Color tmp = sR.color;
            tmp.a = 0f;
            sR.color = tmp;
            _colider.enabled = false;
        }

    }

    private void StartCounting()
    {

        if (contador < 2f)
        {
            contador += Time.deltaTime;
        }
        else
        {
            //print(contador);
            contador = 0;
            SetConstrain2();
            //_rigidBody.gravityScale = 5;
        }



    }

    public void ResetPosition()
    {
        transform.position = posicaoInicial;
        //_rigidBody.gravityScale = 0;
        colidiu = false;
        SetConstrain1();
    }

}
