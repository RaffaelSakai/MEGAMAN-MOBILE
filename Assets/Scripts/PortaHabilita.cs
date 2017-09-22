using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaHabilita : MonoBehaviour
{

    SpriteRenderer sR;
    BoxCollider2D _collider2d;
    public bool inside;

    void Start()
    {

        sR = GetComponent<SpriteRenderer>();
        _collider2d = GetComponent<BoxCollider2D>();

    }


    void Update()
    {
        Vector3 distance = transform.position - playerTransform.position;

        if (distance.magnitude <= 2.5 && distance.x > 0)
        {
            DesligaComponentes();
        }
        else if (distance.x < -1)
        {
            Invoke("ReLigaComponentes", 0.5f);
        }

    }

    void DesligaComponentes()
    {
        Color tmp = sR.color;
        tmp.a = 0f;
        sR.color = tmp;
        _collider2d.enabled = false;
    }

    void ReLigaComponentes()
    {
        Color tmp = sR.color;
        tmp.a = 1f;
        sR.color = tmp;
        _collider2d.enabled = true;
        inside = true;
    }

    Transform playerTransform
    {
        get { return GameObject.Find("Zero").transform; }
    }

}
