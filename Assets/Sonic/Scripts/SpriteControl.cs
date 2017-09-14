using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteControl : MonoBehaviour
{

    //implementar animação de breaking


    [SerializeField]
    SpriteRenderer renderer;
    [SerializeField]
    Sprite Idle;
    [SerializeField]
    Sprite[] Boring;
    [SerializeField]
    Sprite[] Walk;
    [SerializeField]
    Sprite[] Running;
    [SerializeField]
    Sprite[] Duck;
    [SerializeField]
    Sprite[] Jumping;
    [SerializeField]
    Sprite[] Breaking;
    [SerializeField]
    

    AudioSource aud;
    [SerializeField]

    AudioClip[] clips;

    bool audioonce = false;

    float timecount = 0;


    public float velocity;


    [SerializeField]
    bool ducking = false;

    [SerializeField]
    Rigidbody2D rdb;


    [SerializeField]
    int rings = 0;
    [SerializeField]
    int lives = 3;

    [SerializeField]
    GameObject ringpref;

    bool cooldown = false;


    float boringIndex = 0;
    float walkIndex = 0;
    float runningIndex = 0;
    float jumpingIndex = 0;
    float breakingIndex = 0;
    float duckIndex = 0;

    float jumpforce;
    bool jump;
    
    public Vector3 RespawnPos;

    bool overHundred=false;
    // Use this for initialization
    void Start()
    {
        jump = false;

        RespawnPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        timecount += Time.deltaTime;
        Turn();

        if (Mathf.Abs(rdb.velocity.x) > 0)
        {

            if (Mathf.Abs(rdb.velocity.x) > 6) //Se estiver em uma velocidade entre 0.1 e 0.5
            {
                RunAnim();
            }

            else//Se estiver em uma velocidade maior que 0.5f
            {
                WalkAnim();
            }
            //Mode Aula05 : Calcula a diferença entre a velocidade e a tecla
            float dif = rdb.velocity.normalized.x - velocity * transform.up.y;   //Isso aqui é normalização de vetor]

            if (Mathf.Abs(dif) > 1)
            {
                BreakAnim();
            }


        }
        else  // se estiver parado (velocidade 0)
        {
            IdleAnim();
        }


        if (jump == true)
        {
            if (!audioonce)
            {
                audioonce = true;
                aud.Play();

            }
            JumpAnim();
            rdb.AddForce(new Vector2(0, jumpforce * 0.7f), ForceMode2D.Impulse);//adiciona forca
            jumpforce = Mathf.Lerp(jumpforce, 0, Time.deltaTime * 30);//reduz pra 0
        }

        
    }

   

    public void SetVelocity(float vel)
    {
        velocity = vel;
    }

    public void SetJump()
    {
        if (!jump)//se não tiver pulado (fisica de pulo)
        {

            jumpforce = 10;
            jump = true;
        }
    }


    void FixedUpdate()
    {
        rdb.AddRelativeForce(new Vector2(velocity, 0) * 10);




        RaycastHit2D hit; //contem informacao da colisao
        //traca um raio ate o chao
        hit = Physics2D.Raycast(transform.position, -transform.up, 1);
        //aplicando a normal da colisao na orientacao do player
        if (hit) //fix do bug de giro
        {
            transform.up = hit.normal;
            rdb.AddRelativeForce(new Vector2(0, -rdb.velocity.sqrMagnitude) * 0.1f);
        }
        else
        {
            transform.up = Vector3.up;

        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Ground") || col.gameObject.tag=="Block")
        {
            jump = false;
            Resetaudio();
        }

        if (col.gameObject.name.Contains("Death"))
        {
            cooldown = true;

            Invoke("ReseCooldown", 1);
            rdb.AddForce(col.relativeVelocity.normalized*-300);

            if (rings > 0)
            {
                aud.PlayOneShot(clips[2]);//faz o som
                for (int i = 0; i < rings; i++) //varre as moedas
                {
                    GameObject ringistance = (GameObject) //guarda a referencia
                        Instantiate(ringpref, transform.position, //instancia o anel
                        transform.rotation);

                    Rigidbody2D rdbinstance =
                        ringistance.GetComponent<Rigidbody2D>();//caputa o rigdbody
                    rdbinstance.AddForce(new Vector3(i % 2, 1, 0) * 300);//aplica forca pra cima
                }
                overHundred = false;
                rings = 0;
                MainGame.instance.setRing(rings);
            }
            else
            {
                aud.PlayOneShot(clips[3]);//faz o som de morrer
                if (lives > 0)
                {
                    lives--;
                    MainGame.instance.setLives(lives);
                    transform.position = RespawnPos;
                }
                else
                { SceneManager.LoadScene("GameOver"); }


            }
            
            /* for (int i = 0; i < rings; i++)
            {
                aud.PlayOneShot(clips[1]);
                GameObject ringinstance =(GameObject) Instantiate(ringpref, transform.position, transform.rotation);

                Rigidbody2D rdbinstance = ringinstance.GetComponent<Rigidbody2D>();
                rdbinstance.AddForce(Vector3.up * 100);

            }
            rings = 0;
            */

        }

    }

    void ReseCooldown()
    {
        cooldown = false;


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Pit"))
        {
           // gameObject.SetActive(false);

            transform.position = RespawnPos;

            aud.PlayOneShot(clips[2]);

            rings = 0;
            MainGame.instance.setRing(rings);

            if (lives > 0)
            {
                lives--;
                MainGame.instance.setLives(lives);
                transform.position = RespawnPos;
            }
            else
            { SceneManager.LoadScene("GameOver"); }
        }


        //Faz o som de pegar rings , destrói as argolas e adiciona a quantidade
        if (!cooldown && col.gameObject.name.Contains("Ring"))
        {  
            overHundred = false;
            aud.PlayOneShot(clips[0]);
            Destroy(col.gameObject);
            rings++;
            MainGame.instance.setRing(rings);
            if (rings % 100 == 0)
            { lives++;
            
            }
        }
        if (!cooldown &&  col.gameObject.tag == "SuperRing")
        {
            
            aud.PlayOneShot(clips[0]);
            Destroy(col.gameObject);
            rings=rings+99;
            MainGame.instance.setRing(rings);
          
        }


        if (col.gameObject.tag == "Checkpoint")
        {   
            RespawnPos = col.transform.position;
           
            aud.PlayOneShot(clips[3]);



        }
    }

    

    private void Resetaudio()
    {
        audioonce = false;
    }



    void Turn()
    {

        if (velocity > 0)
        {

            renderer.flipX = false;
        }

        if (velocity < 0)
        {

            renderer.flipX = true;
        }

    }

    /// <Turn>
    /// Essa função (^) é responsável pelo flip da animação do personagem (girar ele do lado inverso).
    /// </Turn>

    void IdleAnim()
    {

        //Começa a contar o tempo


        if (timecount > 5)//Se passou cinco segundos
        {
            boringIndex += Time.deltaTime * 5;//incrementa o indice dos frames
            if (boringIndex > Boring.Length)//não permite o indice etourar o array
            {
                boringIndex = 9;
            }
            renderer.sprite = Boring[((int)boringIndex)];//troca o sprite dependendo do array


        }
        else
        {
            renderer.sprite = Idle;//Chama o sprite padrão
        }


    }

    /// <IdleAnim>
    /// Essa função anima o sonic dependendo da velocidade
    /// </IdleAnim>

    void WalkAnim()
    {
        timecount = 0; //zera o contador

        walkIndex += Mathf.Abs(rdb.velocity.x * 0.08f);//incrementa o indice de troca de animacao pela velocidade

        if (walkIndex > Walk.Length)//não permite o indice estourar o array
        {
            walkIndex = 0;
        }

        renderer.sprite = Walk[((int)walkIndex)]; //troca o sprite dependendo do array
        boringIndex = 0;

    }

    /// <WalkAnim>
    /// Essa função anima o sonic dependendo da velocidade
    /// </WalkAnim>

    void RunAnim()
    {



        timecount = 0; //zera o contador

        runningIndex += Mathf.Abs(rdb.velocity.x * 0.06f);//incrementa o indice de troca de animacao pela velocidade

        if (runningIndex > Running.Length)//não permite o indice estourar o array
        {
            runningIndex = 0;
        }

        renderer.sprite = Running[((int)runningIndex)];//troca o sprite dependendo do array
        boringIndex = 0;


    }

    /// <RunAnim>
    /// Essa função anima o sonic dependendo da velocidade
    /// </RunAnim>
    /// 

    void JumpAnim()
    {



        timecount = 0; //zera o contador

        jumpingIndex += Mathf.Abs(rdb.velocity.y * 0.02f);//incrementa o indice de troca de animacao pela velocidade

        if (jumpingIndex > Jumping.Length)//não permite o indice estourar o array
        {
            jumpingIndex = 0;
        }

        renderer.sprite = Jumping[((int)jumpingIndex)];//troca o sprite dependendo do array
        boringIndex = 0;


    }


    void BreakAnim()
    {



        timecount = 0; //zera o contador

        breakingIndex += Mathf.Abs(rdb.velocity.y * 0.02f);//incrementa o indice de troca de animacao pela velocidade

        if (breakingIndex > Breaking.Length)//não permite o indice estourar o array
        {
            breakingIndex = 0;
        }

        renderer.sprite = Breaking[((int)breakingIndex)];//troca o sprite dependendo do array
        boringIndex = 0;


    }

}


//}