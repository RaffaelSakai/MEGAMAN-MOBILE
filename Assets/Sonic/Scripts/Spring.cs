using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    int cor;

    [SerializeField]
    SpriteRenderer render;
      
    [SerializeField]
    Sprite[] Springing;

     [SerializeField]
    float springIndex = 0;

     [SerializeField]
     AudioSource aud;


     [SerializeField]
     int force ;
    
    
     void OnCollisionEnter2D(Collision2D col) 
        {
          
        if (col.gameObject.GetComponent<Rigidbody2D>()!=null)
         {

             aud.Play();

             if (cor == 0)
             { force = 700; }
             if (cor == 1)
             { force = 900; }
             if (cor == 2)
             { force = 1100; }


             col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
                render.sprite = Springing[4];        
     
          
         
           //render.sprite = Springing[1];
           Invoke("resetspring", 0.5f);
         }
        }

     void resetspring()
     {

         render.sprite = Springing[0];
     
     }


     void SpringAnim()
     {
         for (int i = 0; i < Springing.Length; i++)
         {
             springIndex += i;//incrementa o indice de troca de animacao pela velocidade

             if (springIndex > Springing.Length)//não permite o indice estourar o array
             {
                 springIndex = 0;
             }

             render.sprite = Springing[((int)springIndex)];//troca o sprite dependendo do array
         }
     
     }

}
        

	

