using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teste : MonoBehaviour
{
    Image Render;
    public List<Sprite> sprites;
    float index = 0;
    public int velocidade;
    void Start()
    {
        sprites = RetornaLista();
        Render = GetComponent<Image>();
    }

   
    void Update()
    {

        index += Time.deltaTime * velocidade;
        index = index > sprites.Count ? 0 : index;

        Render.sprite = sprites[(int)index];
    }

    List<Sprite> RetornaLista()
    {
        List<Sprite> Animacoes = new List<Sprite>();

        for (int i = 0; i < 129; i++)
        {
            Animacoes.Add(Resources.Load<Sprite>("FramesBackground/frame_" + i.ToString("000") + "_delay-0.04s"));
        }

        return Animacoes;
    }

}
