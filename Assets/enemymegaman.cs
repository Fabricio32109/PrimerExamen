using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymegaman : MonoBehaviour
{
    int vidas = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bal1")
        {
            vidas =- 2;
            Destroy(other.gameObject);
        }
        if (other.tag == "bal2")
        {
            vidas =- 3;
            Destroy(other.gameObject);
        }
        if (other.tag == "bal3")
        {
            vidas =- 6;
            Destroy(other.gameObject);
        }
    }
}
