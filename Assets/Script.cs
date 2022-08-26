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
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        bc=GetComponent<BoxCollider2D>();
        sr=GetComponent<SpriteRenderer>();
        tf=GetComponent<Transform>();
        am=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity=new Vector2(5,rb.velocity.y);
            sr.flipX=false;
            if(en_suelo==true){
            am.SetInteger("anim",3);
            }
            if(Input.GetKey(KeyCode.X))
                rb.velocity=new Vector2(10,rb.velocity.y);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
            rb.velocity=new Vector2(1,rb.velocity.y);
            am.SetInteger("anim",0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity=new Vector2(-5,rb.velocity.y);
            sr.flipX=true;
            if(en_suelo==true){
            am.SetInteger("anim",3);
            }
            if(Input.GetKey(KeyCode.X))
                rb.velocity=new Vector2(-10,rb.velocity.y);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            rb.velocity=new Vector2(-1,rb.velocity.y);
            am.SetInteger("anim",0);
        }
        if(Input.GetKey(KeyCode.Space)){
            if(en_suelo==true){
                am.SetInteger("anim",2);
                en_suelo=false;
                rb.AddForce(new Vector2(0,7),ForceMode2D.Impulse);
            }
        }
        if(Input.GetKey(KeyCode.Z)&&en_suelo==true){
            am.SetInteger("anim",1);
            ataq=true;
            cont = 0;
        }
        if (ataq == true)
        {
            rb.velocity = new Vector2((float)(rb.velocity.y *-1), rb.velocity.y);
            cont++;
        }
        Debug.Log(cont);
        if (cont > 150)
        {
            ataq = false;
            am.SetInteger("anim", 0);
            cont = 0;
        }
    }

    void OnCollisionEnter2D(){
        am.SetInteger("anim",0);
        en_suelo=true;
    }

}
