using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.up * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 6 && rb.velocity.y<0)
        {
            rb.velocity = -1*rb.velocity;
        }
    }*/
}
