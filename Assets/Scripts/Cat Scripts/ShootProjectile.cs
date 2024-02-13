using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float maxShootDistance = 5f; // Adjust the maximum shooting distance
    private float nextFireTime;

    void Start()
    {
        // Start firing lasers automatically when the cat is instantiated
        nextFireTime = Time.time + 1f / fireRate;
    }

    void Update()
    {
        // Check if it's time to fire again
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Check if there is a robot in line of sight
        if (IsRobotInLineOfSight())
        {
            Quaternion laserRotation = Quaternion.Euler(0f, 0f, 0f);

            Instantiate(laserPrefab, firePoint.position, laserRotation);

        }
    }

    bool IsRobotInLineOfSight()
    {
        RaycastHit hit;

        // Debug log to print the ray direction
        Debug.DrawRay(firePoint.position, firePoint.right * maxShootDistance, Color.red, 2.0f);

        float currentDistance = 0f;

        while (currentDistance < maxShootDistance)
        {
            // Perform a raycast from the firePoint position forward
            if (Physics.Raycast(firePoint.position + firePoint.right * currentDistance, firePoint.right, out hit, maxShootDistance - currentDistance))
            {
                // Check if the hit object has the tag "Robot"
                if (hit.collider.CompareTag("Robot"))
                {
                    // Robot is in line of sight
                    return true;
                }
                else
                {
                    // If it's not a robot, continue the raycast
                    currentDistance += hit.distance + 0.01f; // Offset to prevent hitting the same object again
                }
            }
            else
            {
                // No more hits, exit the loop
                break;
            }
        }

        // No robot in line of sight
        return false;
    }
}