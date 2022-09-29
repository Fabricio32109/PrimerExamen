using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class megascript : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    SpriteRenderer sr;
    Transform tf;
    Animator am;
    bool en_suelo = true;
    bool ataq = false;
    public float vel_cam;
    public float potencia;
    public GameObject Bala1;
    public GameObject Bala2;
    public GameObject Bala3;
    Stopwatch crm = new Stopwatch();
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
            if (en_suelo == true&&ataq==false)
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (en_suelo == true)
            {
                ataq = true;
                crm.Start();
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            TimeSpan ts = crm.Elapsed;
            if (ts.TotalMilliseconds < 3000)
            {
                sr.color = new Color(1f, 1f, 1f, 1f);
            }
            if (ts.TotalMilliseconds >= 3000&& ts.Milliseconds < 5000)
            {
                sr.color = new Color(0f, 1f, 0f, 1f);
            }
            if (ts.TotalMilliseconds > 5000)
            {
                sr.color = new Color(1f, 0f, 0f, 1f);
            }
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            TimeSpan ts = crm.Elapsed;
            if (ts.TotalMilliseconds < 3000)
            {

                var gb = Instantiate(Bala1, new Vector2(tf.position.x + 1, tf.position.y), Quaternion.identity) as GameObject;
            }
            if (ts.TotalMilliseconds >= 3000 && ts.Milliseconds < 5000)
            {

                var gb = Instantiate(Bala2, new Vector2(tf.position.x + 1, tf.position.y), Quaternion.identity) as GameObject;
            }
            if (ts.TotalMilliseconds > 5000)
            {
                var gb = Instantiate(Bala3, new Vector2(tf.position.x + 1, tf.position.y), Quaternion.identity) as GameObject;
            }
            sr.color = new Color(1f, 1f, 1f, 1f);
            crm.Stop();
            crm.Reset();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        en_suelo = true;
    }
}
