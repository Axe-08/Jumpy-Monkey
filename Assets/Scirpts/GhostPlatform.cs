using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : solidPlatform
{
    public float intangibleDuration = 2f;  // Duration for which the platform is intangible
    public float tangibleDuration = 5f;    // Duration for which the platform is tangible
    private Collider2D platformCollider;
  //  private SpriteRenderer platformRenderer; // Assuming you have a SpriteRenderer for visual feedback

    protected override void Start()
    {
        platformCollider = GetComponent<Collider2D>();
       // platformRenderer = GetComponent<SpriteRenderer>();

        // Start the periodic toggle between tangible and intangible
        StartCoroutine(TogglePlatformState());
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }

    IEnumerator TogglePlatformState()
    {
        while (true)
        {
            // Make the platform intangible
            SetPlatformState(false);
            yield return new WaitForSeconds(intangibleDuration);

            // Make the platform tangible
            SetPlatformState(true);
            yield return new WaitForSeconds(tangibleDuration);
        }
    }

    // Method to toggle platform's state
    void SetPlatformState(bool isTangible)
    {
        platformCollider.enabled = isTangible;  // Enable or disable the collider

        // Change platform appearance (e.g., transparency or color)
        if (isTangible)
        {
            Debug.Log("tangible now!!");
          //  platformRenderer.color = new Color(1f, 1f, 1f, 1f);  // Fully visible
          //animation
        }
        else
        {
            Debug.Log("Intagible Now!!");
          //  platformRenderer.color = new Color(1f, 1f, 1f, 0.5f);  // Semi-transparent to indicate intangibility
          //animation
        }
    }
}
