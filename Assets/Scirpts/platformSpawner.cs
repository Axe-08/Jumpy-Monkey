using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
  //  [SerializeField] GameObject[] PlatformPrefabs;
//    [SerializeField] int[] WeightOfPlatformSpawn;
    public float spawnRate = 2f;
    public float platformXMin = -3f;
    public float platformXMax = 3f;
    public float platformXOffset = 10f;
    public GameObject monke;

    public Platform[] platforms = new Platform[7];

    private float nextSpawn = 0f;

    private void Start()
    {
        monke = GameObject.FindGameObjectWithTag("monke");
    }

    void Update()
    {   
        if(monke.GetComponent<Rigidbody2D>().velocity.y>0){
            if (Time.time > nextSpawn)
            {
                int nowSpawning = GetUnfairRandom();
                Vector3 spawnPosition = new Vector3(Random.Range(platformXMin, platformXMax), transform.position.y, 0);
                Instantiate(platforms[nowSpawning].PlatformPrefab, spawnPosition, Quaternion.identity);
                nextSpawn = Time.time + 1f * spawnRate;
            }
        }
        int GetUnfairRandom()
        {
            // Define weights for each number from 0 to 8
            // The higher the number, the higher the probability
            int[] weights = new int[] { 1, 5, 2, 8, 3, 4, 6, 7, 20 }; // Example weights

            // Total weight sum
            int totalWeight = 0;
            foreach (int weight in weights)
            {
                totalWeight += weight;
            }

            // Get a random number between 0 and total weight
            int randomValue = Random.Range(0, totalWeight);

            // Find the random number based on the weights
            int cumulativeWeight = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                cumulativeWeight += weights[i];
                if (randomValue < cumulativeWeight)
                {
                    return i;  // Return the index (which is the random number)
                }
            }

            // Default return, should not be hit
            return 0;
        }
    }
}
