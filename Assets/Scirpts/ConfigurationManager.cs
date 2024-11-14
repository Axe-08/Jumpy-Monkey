using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    public static ConfigurationManager Instance { get; private set; }

    // Example variables to control different GameObjects
    public float bounceForce = 10f;
    public float platformSpeed = 5f;
    public float gravityScale = 1f;

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the manager persistent across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
