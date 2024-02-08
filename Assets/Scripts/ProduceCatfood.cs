using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceCatfood : MonoBehaviour
{
    public GameObject catfoodPrefab;
    public float productionInterval = 5f; // Adjust the interval between Catfood production
    public float spawnRadius = 2f; // Adjust the radius for random spawn

    private float nextProductionTime;

    void Start()
    {
        nextProductionTime = Time.time + productionInterval;
    }

    void Update()
    {
        if (Time.time >= nextProductionTime)
        {
            ProduceCatfoodPrefab();
            nextProductionTime = Time.time + productionInterval;
        }
    }

    void ProduceCatfoodPrefab()
    {
        // Calculate a random angle in radians
        float randomAngle = Random.Range(45f, 45f) * Mathf.Deg2Rad;

        // Calculate the spawn position based on the angle and radius
        Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * spawnRadius;

        // Spawn the Catfood prefab at the random position
        Instantiate(catfoodPrefab, spawnPosition, Quaternion.identity);
    }
}