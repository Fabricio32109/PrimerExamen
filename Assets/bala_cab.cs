using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala_cab : MonoBehaviour
{
    Rigidbody2D rb;
    public int vel;
    gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<gameManager>();
        Destroy(this.gameObject, 5);//eliminacion del objeto

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(vel,0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);//eliminacion del objeto
            Destroy(this.gameObject);//eliminacion del objeto
            gm.ganpuntos(10);
        }
    }
}
