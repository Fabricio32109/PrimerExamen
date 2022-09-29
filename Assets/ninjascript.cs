using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjascript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    SpriteRenderer sr;
    Transform tf;
    Animator am;
    public float vel_cam;
    public float potencia;
    bool en_suelo = true;
    bool ataq = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        am = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (en_suelo == true)
        {
            am.SetInteger("anim", 0);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(vel_cam, rb.velocity.y);
            sr.flipX = false;
            if (en_suelo == true)
            {
                am.SetInteger("anim", 1);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(vel_cam / 10, rb.velocity.y);
            sr.flipX = false;
            if (en_suelo == true)
            {
                am.SetInteger("anim", 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-vel_cam, rb.velocity.y);
            sr.flipX = true;
            if (en_suelo == true)
            {
                am.SetInteger("anim", 1);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-vel_cam / 10, rb.velocity.y);
            sr.flipX = true;
            if (en_suelo == true)
            {
                am.SetInteger("anim", 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (en_suelo == true && ataq == false)
            {
                en_suelo = false;
                rb.AddForce(new Vector2(0, potencia), ForceMode2D.Impulse);
                am.SetInteger("anim", 2);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (en_suelo == true && ataq == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 10);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        en_suelo = true;
    }
}
