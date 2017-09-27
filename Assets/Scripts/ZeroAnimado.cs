using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroAnimado : MonoBehaviour
{

    Image imagem;
    int valorAleatorio;

    public int Limite1, Limite2;

    [SerializeField]
    Sprite[] animacaoAtual;
    [SerializeField]
    Sprite[] idle, walk, charge;

    public int Velocidade;

    float index;
    void Start()
    {
        index = 0;
        imagem = GetComponent<Image>();

        SetSprites();
        animacaoAtual = idle;

    }

    void Update()
    {
        if (animacaoAtual == idle)
        {

            Contador(Limite1);
        }
        else
        {
            ContadorReseta(Limite2);
        }

        PlayArray(animacaoAtual);

    }

    void SetSprites()
    {
        idle = SpriteManager.CarregaSprite("Zero/Idle");
        walk = SpriteManager.CarregaSprite("Zero/Walking");
        charge = SpriteManager.CarregaSprite("Zero/Charging Walking");

    }


    float somaReseta = 0;
    void ContadorReseta(int valorLimite)
    {
        somaReseta += Time.deltaTime;

        if (somaReseta >= valorLimite)
        {
            somaReseta = 0;
            animacaoAtual = idle;
        }
    }


    float soma = 0;
    void Contador(int valorLimite)
    {
        soma += Time.deltaTime;

        if (soma >= valorLimite)
        {
            soma = 0;
            int numeroEscolhido = valorAleatorio;
            valorAleatorio = Random.Range(0, 3);
            while (valorAleatorio == numeroEscolhido)
            {
                valorAleatorio = Random.Range(0, 2);
            }
            index = 0;
            TrocaAnimacao(valorAleatorio);
        }
    }

    void TrocaAnimacao(int numero)
    {
        switch (numero)
        {
            case 0:
                animacaoAtual = walk;
                break;
            case 1:
                animacaoAtual = charge;
                break;

        }

    }

    void PlayArray(Sprite[] arrayDeSprites)
    {
        float soma = Time.deltaTime * Velocidade;
        index += soma;
        index = index > arrayDeSprites.Length ? 0 : index;
        imagem.sprite = arrayDeSprites[(int)index];
    }

}
