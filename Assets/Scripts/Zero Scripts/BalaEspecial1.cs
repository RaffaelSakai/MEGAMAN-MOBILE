﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BalaEspecial1 : BulletBaseClass
{

   [SerializeField] Sprite[] SpritesAnimadas;


    void Awake()
    {
        animaIndex = 0;
        SpritesAnimadas = SpriteManager.CarregaSprite("Zero/Projeteis/tiro especial 1");
        dano = 5;
        setComponents();
        colidiu = false;
    }

    void Update()
    {
        Navega();
        RodaContador();

        AnimaSprite(velocidadeTrocaSprite);
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


    public override void RodaContador()
    {
        if (contador < contadorMax)
        {
            contador += Time.deltaTime;
        }
    }

    protected override void AnimaSprite(int SpeedChangeSprite)
    {
        float addValue = Time.deltaTime * SpeedChangeSprite;
        animaIndex += addValue;
        animaIndex = animaIndex > SpritesAnimadas.Length ? 1 : animaIndex;

        _mySpriteRenderer.sprite = SpritesAnimadas[(int)animaIndex];
    }

}
