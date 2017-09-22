﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPadrao : BulletBaseClass
{



    void Start()
    {
        dano = 2;
        setComponents();
        colidiu = false;
    }

    void Update()
    {
        Navega();
        RodaContador();


        if (colidiu || contador >= contadorMax)
        {
            RetiraDaTela();
        }
    }

    public override void Navega()
    {
        //_myRigidBody.AddForce(transform.right * velocidade);

        transform.position += transform.right * velocidade / 60;

    }

    public override void RetiraDaTela()
    {
        Destroy(gameObject);
    }

    protected override void setComponents()
    {
        base.setComponents();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (!collision.GetComponent<Collider2D>().isTrigger && collision.gameObject.tag != "Player")
        {
            //if (collision.gameObject.GetComponent<ZeroControl>())
            //{
            //    collision.gameObject.GetComponent<ZeroControl>().HealthValue -= dano;
            //}
            colidiu = true;
        }

    }


    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (!col.collider.isTrigger && !col.gameObject.CompareTag("Player"))
    //    {
    //        colidiu = true;
    //    }
    //}

    public override void RodaContador()
    {
        if (contador < contadorMax)
        {
            contador += Time.deltaTime;
        }
    }



}
