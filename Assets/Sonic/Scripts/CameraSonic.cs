using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSonic : MonoBehaviour {

    public GameObject Player;
    public float Num;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+Num, transform.position.z);
		
	}
}
