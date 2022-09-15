using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_real : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    SpriteRenderer sr;
    Transform tf;
    Animator am;
    bool ataq = false;
    int cont = 0;
    bool en_suelo = true;
    bool doblesalto = false;
    bool interr = true;
    public int vel_cam = 5;
    public int vel_run = 10;
    public int potencia = 10;
    public int seg_potencia = 10;
    public int balas;
    public GameObject Bala;
    gameManager gm;
    bool muerto = false;
    int cart = 0;
    Vector2 respawn = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<gameManager>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        am = GetComponent<Animator>();
        respawn = new Vector2(-7, -3);
        sr.flipX = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (en_suelo == true && muerto == false)
        {
            am.SetInteger("anim", 0);
        }

        
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity=new Vector2(vel_cam, rb.velocity.y);
            sr.flipX=false;
            if(en_suelo==true){
            am.SetInteger("anim",4);
            }
            if (Input.GetKey(KeyCode.X) && en_suelo == true)
            {
                am.SetInteger("anim", 3);
                rb.velocity = new Vector2(vel_run, rb.velocity.y);
            }
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
            rb.velocity=new Vector2(1,rb.velocity.y);
            if (en_suelo == true)
                am.SetInteger("anim",0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity=new Vector2(-vel_cam, rb.velocity.y);
            sr.flipX=true;
            if(en_suelo==true){
            am.SetInteger("anim",4);
            }
            if (Input.GetKey(KeyCode.X)&&en_suelo==true)
            {
                am.SetInteger("anim", 3);
                rb.velocity = new Vector2(-vel_run, rb.velocity.y);
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            rb.velocity=new Vector2(-1,rb.velocity.y);
            if(en_suelo==true)
                am.SetInteger("anim",0);
        }
        if (Input.GetKey(KeyCode.Space) && muerto == false)
        {

            if (en_suelo == false && doblesalto == true)
            {
                doblesalto = false;
                rb.AddForce(new Vector2(0, seg_potencia), ForceMode2D.Impulse);
            }
            if (en_suelo == true && ataq == false && doblesalto == false)
            {
                am.SetInteger("anim", 1);
                //am.SetInteger("anim", 2);
                en_suelo = false;
                rb.AddForce(new Vector2(0, potencia), ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && muerto == false)
        {
            //disparo
            if (gm.getbalas() > 0)
            {
                var gb = Instantiate(Bala, new Vector2(tf.position.x + 1, tf.position.y), Quaternion.identity) as GameObject;
                gm.perderbalas();
            }
        }
        if (Input.GetKey(KeyCode.C) && en_suelo == false)
        {
            rb.gravityScale = (float)0.05;
        }
        if (Input.GetKeyUp(KeyCode.C) && en_suelo == false)
        {
            rb.gravityScale = 1;
        }
        if (gm.getvidas() <= 0)
        {
            muerto = true;
            Destroy(rb);
            bc.enabled = false;
            am.SetInteger("anim", 2);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 10);
            if (interr == true)
            {
                doblesalto = true;
                interr = false;
            }
        }
        if (Input.GetKey(KeyCode.Z) && en_suelo == true)
        {
            am.SetInteger("anim", 1);
            ataq = true;
            cont = 0;
        }
        if (ataq == true)
        {
            rb.velocity = new Vector2((float)(rb.velocity.y * -1), rb.velocity.y);
            cont++;
        }
        if (cont > 150 && en_suelo == true)
        {
            ataq = false;
            am.SetInteger("anim", 0);
            cont = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        en_suelo = true;
        doblesalto = false;
        interr = true;

        if (other.gameObject.tag == "Enemy")
        {
            gm.perdervidas();
            //am.SetInteger("anim", 2);
            //muerto = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
            bc.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            other.enabled = false;
            respawn = new Vector2(rb.transform.position.x, rb.transform.position.y);
        }
        if (other.tag == "Finish")
        {
            rb.transform.position = respawn;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.W))
        {
            tf.transform.position = new Vector2(tf.transform.position.x, tf.transform.position.y + (float)0.05);
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 0;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.gravityScale = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 0;
            bc.enabled = false;
            tf.transform.position = new Vector2(tf.transform.position.x, tf.transform.position.y - (float)0.05);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = 1;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Escalera")
        rb.gravityScale = 1;

    }
}
