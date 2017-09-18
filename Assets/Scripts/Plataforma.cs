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
    // Use this for initialization
    void Start()
    {
        posicaoInicial = transform.position;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.gravityScale = 5;
        _rigidBody.mass = 200;
        contador = 0;
        colidiu = false;
    }

    // Update is called once per frame
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
        _rigidBody.constraints =  RigidbodyConstraints2D.FreezeRotation;
    }


    void SetConstrain1()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colidiu = true;
        }
    }

    private void StartCounting()
    {

        if (contador < 1f)
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
