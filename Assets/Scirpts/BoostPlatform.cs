using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatform : solidPlatform
{
    public float boostVelocity;
    public float boostDuration;
    // Start is called before the first frame update
    protected override void Start()
    {//add animation component and power up disappearance
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public IEnumerator BoostUpward(Rigidbody2D rb)
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
