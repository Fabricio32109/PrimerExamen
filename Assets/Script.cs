using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    SpriteRenderer sr;
    Transform tf;
    Animator am;
    bool ataq=false;
    int cont=0;
    bool en_suelo=true;
    bool doblesalto = false;
    bool interr = true;
    public int vel_cam = 5;
    public int vel_run = 10;
    public int potencia = 10;
    public int seg_potencia = 10;
    int cart = 0;
    Vector2 respawn = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        bc=GetComponent<BoxCollider2D>();
        sr=GetComponent<SpriteRenderer>();
        //tf=GetComponent<Transform>();
        am=GetComponent<Animator>();
        respawn = new Vector2(-7,-3);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKey(KeyCode.Space))
        {
            if (en_suelo == false && doblesalto == true)
            {
                doblesalto = false;
                rb.AddForce(new Vector2(0, seg_potencia), ForceMode2D.Impulse);
            }
            if (en_suelo == true && ataq == false&&doblesalto==false)
            {
                am.SetInteger("anim", 2);
                en_suelo = false;
                rb.AddForce(new Vector2(0, potencia), ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y/10);
            if (interr == true)
            {
                doblesalto = true;
                interr = false;
            }
        }
        if (Input.GetKey(KeyCode.Z)&&en_suelo==true){
            am.SetInteger("anim",1);
            ataq=true;
            cont = 0;
        }
        if (ataq == true)
        {
            rb.velocity = new Vector2((float)(rb.velocity.y *-1), rb.velocity.y);
            cont++;
        }
        if (cont > 150&&en_suelo==true)
        {
            ataq = false;
            am.SetInteger("anim", 0);
            cont = 0;
        }
    }

    void OnCollisionEnter2D()
    {
        am.SetInteger("anim", 0);
        en_suelo = true;
        doblesalto = false;
        interr = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn" &&cart<2)
        {
            cart++;
            respawn = new Vector2(rb.transform.position.x, rb.transform.position.y);
        }
        if (other.tag == "Finish")
        {
            rb.transform.position = respawn;
        }
    }

}
