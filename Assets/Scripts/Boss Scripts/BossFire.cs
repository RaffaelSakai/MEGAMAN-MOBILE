using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    [SerializeField]
    GameObject tiro;

    [SerializeField]
    Transform pontoDoTiro;

    [SerializeField]
    BossAI bossAI;

    int valorAleatorio;


   

    void Start()
    {
        SetStart();
    }

    void Update()
    {
        SetFire();
        SetRandom();
    }

    void SetStart()
    {
        bossAI = GetComponent<BossAI>();

        tiro = carregaGameObject("Boss/Fire Boss");

        Transform[] transformsChildren = GetComponentsInChildren<Transform>();

        foreach (Transform tr in transformsChildren)
        {
            if (tr != gameObject.transform)
            {
                if (tr.name == "PontoDoTiro")
                {
                    pontoDoTiro = tr;
                }
            }
        }

        valorAleatorio = Random.Range(0, 2);
    }

    void SetFire()
    {
        if (bossAI.canFire)
        {
            if (valorAleatorio == 0)
            {
                Vector3 direcaoTiro = (bossAI.PlayerTransform.position - pontoDoTiro.position);

                if (direcaoTiro.magnitude > 1)
                    direcaoTiro.Normalize();

                AddFireValue(0.3f, direcaoTiro);
            }
        }else
        {
            soma = 0;
        }
    }

    float somaAleatorio = 0;
    void SetRandom()
    {
        somaAleatorio += Time.deltaTime;
        if (somaAleatorio >= 8)
        {
            somaAleatorio = 0;
            valorAleatorio = ++valorAleatorio % 2;
        }
    }

    float soma = 0;
    void AddFireValue(float fireRate, Vector3 direcao)
    {
        soma += Time.deltaTime;
        if (soma >= fireRate)
        {
            soma = 0;
            Shoot(direcao);
        }
    }

    void Shoot(Vector3 direcao)
    {
        GameObject obj = Instantiate(tiro, pontoDoTiro.position, pontoDoTiro.rotation);
        obj.GetComponent<TiroInimigo>().SetDirecao(direcao);
    }

    GameObject carregaGameObject(string Path)
    {
        return Resources.Load<GameObject>(Path);
    }


}
