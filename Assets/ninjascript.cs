using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TMP_Text arma;
    public GameObject Bala;
    public GameObject Katana;
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
        if (en_suelo == true&&vel_cam==0)
        {
            am.SetInteger("anim", 0);
        }else if (en_suelo == true)
        {
            am.SetInteger("anim", 1);
        }
        rb.velocity = new Vector2(vel_cam, rb.velocity.y);
    }
    public void der()
    {
        vel_cam = 9;
        sr.flipX = false;
        if (en_suelo == true)
        {
            am.SetInteger("anim", 1);
        }
    }
    public void izq()
    {
        vel_cam = -9;
        sr.flipX = true;
        if (en_suelo == true)
        {
            am.SetInteger("anim", 1);
        }
    }
    public void soltar()
    {
        vel_cam = 0;
    }
    public void saltar()
    {
        if (en_suelo == true && ataq == false)
        {
            en_suelo = false;
            rb.AddForce(new Vector2(0, potencia), ForceMode2D.Impulse);
            am.SetInteger("anim", 2);
        }
    }
    public void solsalto()
    {
        if (en_suelo == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 10);
        }
    }
    public void ataque()
    {
        if (arma.text == "Katana")
        {
            var gb = Instantiate(Katana, new Vector2(tf.position.x + 1, tf.position.y), Quaternion.identity) as GameObject;
        }
        else
        {
            var gb = Instantiate(Bala, new Vector2(tf.position.x + 1, tf.position.y), Quaternion.identity) as GameObject;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        en_suelo = true;
    }
}
