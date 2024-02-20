using System.Collections;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    public GameObject[] robotPrefabs;
    public int numberOfRobots = 5;
    public int bigWaveThreshold = 15; // Adjust the threshold for the big wave
    public int bigWaveSize = 10; // Adjust the number of robots in the big wave
    public float initialDelay = 10f; // Adjust the initial delay in seconds

    void Start()
    {
        StartCoroutine(StartDelayedSpawn());
    }

    IEnumerator StartDelayedSpawn()
    {
        Debug.Log("Initial Delay Started");
        yield return new WaitForSeconds(initialDelay);
        Debug.Log("Initial Delay Stopped");
        StartCoroutine(SpawnRobotsWithRandomIntervals());
    }

    IEnumerator SpawnRobotsWithRandomIntervals()
    {
        int totalRobotsSpawned = 0;

        while (true)
        {
            // Get a random robot prefab
            GameObject randomRobotPrefab = robotPrefabs[Random.Range(0, robotPrefabs.Length)];

            // Get a random spawn point with a 45-degree rotation on the x-axis
            Vector3 spawnPoint = GetRandomSpawnPoint();
            Quaternion spawnRotation = Quaternion.Euler(45f, 0f, 0f);

            // Instantiate the robot at the spawn point with the rotation
            Instantiate(randomRobotPrefab, spawnPoint, spawnRotation);

            totalRobotsSpawned++;

            // Check if it's time for the big wave
            if (totalRobotsSpawned >= bigWaveThreshold)
            {
                Debug.Log("Big Wave Triggered");
                StartCoroutine(SpawnBigWave());
                // Reset the total spawned count
                totalRobotsSpawned = 0;
            }

            // Get a random delay between 30 and 60 seconds
            float randomDelay = Random.Range(5f, 10f);

            // Wait for the next spawn
            yield return new WaitForSeconds(randomDelay);
        }
    }

    IEnumerator SpawnBigWave()
    {
        for (int i = 0; i < bigWaveSize; i++)
        {
            // Get a random robot prefab for the big wave
            GameObject randomRobotPrefab = robotPrefabs[Random.Range(0, robotPrefabs.Length)];

            // Get a random spawn point with a 45-degree rotation on the x-axis
            Vector3 spawnPoint = GetRandomSpawnPoint();
            Quaternion spawnRotation = Quaternion.Euler(45f, 0f, 0f);

            // Instantiate the robot at the spawn point with the rotation
            Instantiate(randomRobotPrefab, spawnPoint, spawnRotation);

            // Wait for a short interval between each robot in the big wave
            yield return new WaitForSeconds(0.2f);
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        // Define an array of specific spawn points with adjusted x-coordinates
        Vector3[] spawnPoints = {
            new Vector3(4f, 1.2f, 0f),
            new Vector3(4f, 1.2f, 0.64f),
            new Vector3(4f, 1.2f, 1.28f),
            new Vector3(4f, 1.2f, 1.96f),
            new Vector3(4f, 1.2f, 2.56f)
        };

        if (spawnPoints.Length > 0)
        {
            // Choose a random spawn point
            Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            return randomSpawnPoint;
        }
        else
        {
            Debug.LogError("No spawn points defined. Please add spawn points to the array.");
            // Return a default spawn point or handle the error as needed
            return Vector3.zero;
        }
    }
}