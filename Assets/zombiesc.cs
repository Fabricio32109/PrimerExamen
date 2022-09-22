using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiesc : MonoBehaviour
{
    Rigidbody2D rb;
    public int vel = 6;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(vel, rb.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag!="mon_oro"&&other.tag!="mon_plata")
        vel *= -1;
    }
}
