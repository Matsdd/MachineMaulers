using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatfoodBank : MonoBehaviour
{
    private int catfoodAmount = 0;

    public int CatfoodAmount
    {
        get { return catfoodAmount; }
    }

    // Method to add Catfood to the bank
    public void AddCatfood(int amount)
    {
        catfoodAmount += amount;
        Debug.Log($"Added {amount} Catfood. Total Catfood: {catfoodAmount}");
    }

    // Method to spend Catfood
    public bool SpendCatfood(int amount)
    {
        if (catfoodAmount >= amount)
        {
            catfoodAmount -= amount;
            Debug.Log($"Spent {amount} Catfood. Remaining Catfood: {catfoodAmount}");
            return true; // Successfully spent Catfood
        }
        else
        {
            Debug.Log("Insufficient Catfood.");
            return false; // Insufficient Catfood
        }
    }
}