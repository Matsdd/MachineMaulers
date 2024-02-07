using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed = 1f; // Adjust the speed of the enemy
    public float leftBound = -5f; // Adjust the point where the enemy should stop moving
    public int damageToCat = 1; // Adjust the damage dealt to the cat
    public float damageInterval = 1f; // Adjust the interval between damage to the cat
    public bool Fighting = false;

    private float nextDamageTime;
    private Cat currentTargetCat; // Track the current target cat for this enemy instance

    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the enemy has reached the left bound
        if (transform.position.x < leftBound)
        {
            EndReached();
        }

        // Check if it has killed the current target cat
        

        // Continuous damage every second
        if (Time.time >= nextDamageTime)
        {
            if (currentTargetCat != null)
            {
                DealContinuousDamage();
            }

            nextDamageTime = Time.time + damageInterval;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the encountered object has the "Cat" tag
        if (other.CompareTag("Cat"))
        {
            Debug.Log("Collided with Cat");

            // Stop the enemy's movement
            speed = 0f;

            Fighting = true;
            currentTargetCat = other.GetComponent<Cat>();
        }
    }

    // Function to deal continuous damage every second
    void DealContinuousDamage()
    {
        if (currentTargetCat != null)
        {
            currentTargetCat.TakeDamage(damageToCat);
        }
        if (currentTargetCat != null && currentTargetCat.GetCurrentHealth() <= 0)
        {
            currentTargetCat = null; // Reset the target cat
            speed = 0.5f; // Resume normal speed
        }
    }

    void EndReached()
    {
        // Stop its movement
        speed = 0f;
    }
}