using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class monkeScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float monkeUpperBound = 0;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();


    }
    //make method for bouncing

    public bool isFalling()
    {
        if (GetComponent<Rigidbody2D>().velocity.y <= 0) { return true; }
        else { return false; }
    }
    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      //optimise callling of this method later
        if (collision.gameObject.CompareTag("solidPlatform"))

        {
            solidPlatform platformScript = collision.gameObject.GetComponent<solidPlatform>();

            rb.velocity = new Vector2(rb.velocity.x, 3f * platformScript.bounceFactor);
        }
        else if(collision.gameObject.CompareTag("movingPlatform")){
            MovingPlatformMovement platformScript = collision.gameObject.GetComponent<MovingPlatformMovement>();
            rb.velocity = new Vector2(rb.velocity.x, 3f * platformScript.bounceFactor);
        }
       // else if (collision.gameObject.CompareTag("spikedPlatform"))
       // {
          //  gameOver();
       // }
        else if (collision.gameObject.CompareTag("bouncingPlatform"))
        {
            BouncingPlatform platformScript = collision.gameObject.GetComponent<BouncingPlatform>();
            rb.velocity = new Vector2(rb.velocity.x, 3f * platformScript.BounceFactor());
        }
        else if (collision.gameObject.CompareTag("boostPlatform"))
        {
            BoostPlatform platformScript = collision.gameObject.GetComponent<BoostPlatform>();
            StartCoroutine(BoostUpward(rb,platformScript.boostVelocity,platformScript.boostDuration));
        }
        else if (collision.gameObject.CompareTag("ghostPlatform"))
        {
            GhostPlatform platformScript = collision.gameObject.GetComponent<GhostPlatform>();
            rb.velocity = new Vector2(rb.velocity.x,3f*platformScript.bounceFactor);
        }
        else if (collision.gameObject.CompareTag("leafPlatform"))
        {
            LeafPlatform platformScript = collision.gameObject.GetComponent<LeafPlatform>();
            rb.velocity = new Vector2(rb.velocity.x, 3f * platformScript.bounceFactor);
            platformScript.destruction();
        }
        else if (collision.gameObject.CompareTag("periodicSpikePlatform"))
        {
            PeriodicSpikePlatform platformScript = collision.gameObject.GetComponent<PeriodicSpikePlatform>();
            if(collision.collider == collision.gameObject.GetComponent<BoxCollider2D>())
            {
                rb.velocity = new Vector2(rb.velocity.x, 3f * platformScript.bounceFactor);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.CompareTag("spikedPlatform"))
        {
                gameObject.SetActive(false) ;
        }
        else if (collision.gameObject.CompareTag("teleportPlatform"))
        {
            PortalScript platformScript = collision.gameObject.GetComponent<PortalScript>();

            rb.velocity = new Vector2(rb.velocity.x, 3f * platformScript.bounceFactor);
            platformScript.GlitchFixPortal();
            gameObject.GetComponent<Transform>().position = platformScript.targetCoordinate;
            Debug.Log("Teleported player to:" + platformScript.targetCoordinate);

        }


    }

    public IEnumerator BoostUpward(Rigidbody2D rb,float boostVelocity,float boostDuration) //use coroutine in player object ,foreign coroutine instance gets interrupted
    {
        //  isBouncing = true;

        // Disable gravity for the duration of the bounce
        rb.gravityScale = 0;
        Debug.Log("Boost started!");
        // Apply constant upward velocity
        rb.velocity = new Vector2(rb.velocity.x, boostVelocity);

        // Wait for the bounce duration
        yield return new WaitForSeconds(boostDuration);
        Debug.Log("Reverting back to normal gravity");
        // Return to normal physics by re-enabling gravity
        rb.gravityScale = 1;


        // isBouncing = false;
    }
}