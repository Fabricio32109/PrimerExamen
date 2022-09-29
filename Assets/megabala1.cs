using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megabala1 : MonoBehaviour
{
    Transform tf;
    public float vel=5;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position = new Vector2(tf.position.x + vel, tf.position.y);
    }
}
