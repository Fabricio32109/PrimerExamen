using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiesc : MonoBehaviour
{
    Rigidbody2D rb;
    public int vel = -6;
    int vidas = 2;
    managerBot mng;
    // Start is called before the first frame update
    void Start()
    {
        mng = FindObjectOfType<managerBot>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(vel, rb.velocity.y);
        if (vidas == 0)
        {
            Destroy(this.gameObject);//eliminacion del objeto
            mng.ganPuntos(1);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bal1")
        {
            Destroy(other.gameObject);
            vidas-=1;
        }
        if (other.tag == "bal2")
        {
            vidas -= 2;
            Destroy(other.gameObject);
        }
        /*if(other.tag!="mon_oro"&&other.tag!="mon_plata")
        vel *= -1;*/
    }
}
