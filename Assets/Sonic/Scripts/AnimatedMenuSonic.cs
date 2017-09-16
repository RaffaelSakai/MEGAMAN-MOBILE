using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMenuSonic : MonoBehaviour
{

    int valorAleatorio;
    Animator anim;
    public int Limite;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sonic Idle Impaciente"))
        {
            Contador(Limite);
        }
    }

    float soma = 0;
    void Contador(int valorLimite)
    {
        soma += Time.deltaTime;
        print(soma);
        if (soma >= valorLimite)
        {
            soma = 0;
            int numeroEscolhido = valorAleatorio;
            valorAleatorio = Random.Range(0, 3);
            while(valorAleatorio == numeroEscolhido)
            {
                valorAleatorio = Random.Range(0, 3);
            }

            TocaAnimacao(valorAleatorio);
        }
    }

    void TocaAnimacao(int numero)
    {
        anim.Play("Animacao" + numero, -1, 0f);
        //anim.Play("Animacao2", -1, 0f);
    }
}
