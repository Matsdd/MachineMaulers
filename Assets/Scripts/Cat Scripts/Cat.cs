using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    private Tile occupyingTile;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetOccupyingTile(Tile tile)
    {
        occupyingTile = tile;
    }

    // Call this method when the cat dies
    public void NotifyTileOnDeath()
    {
         occupyingTile.SetOccupied(false);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            NotifyTileOnDeath();
            gameObject.SetActive(false);
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}