using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 6f;
    public float lifetime = 2f;
    public int damageToRobot = 1; // Adjust the damage dealt to the robot

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Handle collisions or damage to other objects if needed
        if (other.CompareTag("Robot"))
        {
            // Call the TakeDamage method of the Robot
            Robot robot = other.GetComponent<Robot>();
            if (robot != null)
            {
                robot.TakeDamage(damageToRobot);
            }

            // Destroy the laser GameObject
            Destroy(gameObject);
        }
    }
}