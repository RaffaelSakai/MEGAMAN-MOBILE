using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    public int dano;
    Vector3 direcaoDoAlvo;
    public float velocidade;

    private void Update()
    {
        transform.position += direcaoDoAlvo*velocidade;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.GetComponent<ZeroControl>())
            {
                //ZeroControl zero = collision.gameObject.GetComponent<ZeroControl>();
                //print(zero);
                collision.gameObject.GetComponent<ZeroControl>().HealthValue -= dano;
                collision.gameObject.GetComponent<ZeroFire>().gotHit = true;

            }
            Destroy(gameObject);
        }
    }


    public void SetDirecao(Vector3 direcao)
    {
        if (direcao.magnitude > 1)
        {
            direcao.Normalize();
        }

        direcaoDoAlvo = direcao;
    }
}
