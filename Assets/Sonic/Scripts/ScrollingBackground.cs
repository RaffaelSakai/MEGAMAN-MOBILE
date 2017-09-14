using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{



    private Transform cameraTransform;
    private Transform[] layers;
    private float viewzone =10;
    private int LeftIndex;
    private int RightIndex;

    public float backgroundSize;

	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        LeftIndex = 0;
        RightIndex = layers.Length - 1;



	}


    void ScrollLeft()
    {
        int lastRight = RightIndex;
        layers[RightIndex].position = Vector3.right*(layers[LeftIndex].position.x-backgroundSize);
        LeftIndex = RightIndex;
        RightIndex--;

        if (RightIndex < 0)
        { RightIndex = layers.Length - 1; }
    }

    void ScrollRight()
    {
        int lastLeft = LeftIndex;
        layers[LeftIndex].position = Vector3.right * (layers[RightIndex].position.x + backgroundSize);
        RightIndex = LeftIndex;
        LeftIndex++;

        if (LeftIndex ==layers.Length )
        { LeftIndex = 0; }
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraTransform.position.x <(layers[LeftIndex].transform.position.x+viewzone))
        { ScrollLeft(); }

        if (cameraTransform.position.x > (layers[RightIndex].transform.position.x - viewzone))
        { ScrollRight(); }

	}
}
