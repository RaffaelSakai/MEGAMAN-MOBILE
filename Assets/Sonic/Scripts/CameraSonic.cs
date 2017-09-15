using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSonic : MonoBehaviour
{

    public GameObject Player;
    public float Num;
    public bool canFollow;

    void Start()
    {
        canFollow = true;
    }

    Vector3 posicaoNovaDaCamera;

    void Update()
    {
        posicaoNovaDaCamera = new Vector3(Player.transform.position.x, Player.transform.position.y + Num, transform.position.z);

        if (canFollow)
            //transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Num, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, posicaoNovaDaCamera, Time.deltaTime * 15);
    }
}
