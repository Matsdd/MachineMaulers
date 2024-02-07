using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceCatfood : MonoBehaviour
{
    public GameObject catfoodPrefab;
    public float productionInterval = 5f; // Adjust the interval between Catfood production

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
        // Specify the rotation you want for the spawned Catfood
        Quaternion spawnRotation = Quaternion.Euler(45f, 0f, 0f); // Rotate 90 degrees around the Y-axis

        // Spawn the Catfood prefab at the Cat's position with the specified rotation
        Instantiate(catfoodPrefab, transform.position, spawnRotation);
    }
}