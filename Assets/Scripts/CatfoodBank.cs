using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatfoodBank : MonoBehaviour
{
    private int catfoodAmount = 0;
    public Text catfoodText; // Reference to the UI Text component

    public int CatfoodAmount
    {
        get { return catfoodAmount; }
    }

    void Start()
    {
        UpdateCatfoodText(); // Update UI text at the start
    }

    // Method to add Catfood to the bank
    public void AddCatfood(int amount)
    {
        catfoodAmount += amount;
        UpdateCatfoodText(); // Update UI text after adding catfood
        Debug.Log($"Added {amount} Catfood. Total Catfood: {catfoodAmount}");
    }

    // Method to spend Catfood
    public bool SpendCatfood(int amount)
    {
        if (catfoodAmount >= amount)
        {
            catfoodAmount -= amount;
            UpdateCatfoodText(); // Update UI text after spending catfood
            Debug.Log($"Spent {amount} Catfood. Remaining Catfood: {catfoodAmount}");
            return true; // Successfully spent Catfood
        }
        else
        {
            Debug.Log("Insufficient Catfood.");
            return false; // Insufficient Catfood
        }
    }

    private void UpdateCatfoodText()
    {
        if (catfoodText != null)
        {
            catfoodText.text = catfoodAmount.ToString();
        }
    }
}