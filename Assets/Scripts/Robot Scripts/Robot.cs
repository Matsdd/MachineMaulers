using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float speed = 1f; // Adjust the speed of the enemy
    public float leftBound = -5f; // Adjust the point where the enemy should stop moving
    public int damageToCat = 1; // Adjust the damage dealt to the cat
    public float damageInterval = 1f; // Adjust the interval between damage to the cat
    public bool Fighting = false;

    private float nextDamageTime;
    private Cat currentTargetCat; // Track the current target cat for this enemy instance

    public float maxHealth = 5f; // Adjust the maximum health of the enemy
    private float currentHealth;

    void Start()
    {
        // Initialize the enemy's health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the enemy has reached the left bound
        if (transform.position.x < leftBound)
        {
            EndReached();
        }

        // Continuous damage every second
        if (Time.time >= nextDamageTime)
        {
            if (currentTargetCat != null)
            {
                DealContinuousDamage();
            }

            nextDamageTime = Time.time + damageInterval;
        }

        // Check if the enemy has run out of health
        if (currentHealth <= 0)
        {
            EnemyDefeated();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the encountered object has the "Cat" tag
        if (other.CompareTag("Cat"))
        {
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

    // Function to handle when the enemy has run out of health
    void EnemyDefeated()
    {
        // Perform actions when the enemy is defeated
        gameObject.SetActive(false); // Disable the enemy GameObject or perform other actions as needed
    }

    // Method to make the enemy take damage
    public void TakeDamage(float damageAmount)
    {
        // Reduce health by the damage amount
        currentHealth -= damageAmount;

        // Check if the enemy has run out of health
        if (currentHealth <= 0)
        {
            EnemyDefeated();
        }
    }

    void EndReached()
    {
        // Stop its movement
        speed = 0f;
    }
}