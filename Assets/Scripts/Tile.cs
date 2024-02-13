using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager
    private bool occupied = false; // Flag to track if the tile is occupied

    void Start()
    {
        // Find the GameManager in the scene and store a reference
        gameManager = FindObjectOfType<GameManager>();

        // Check if GameManager is found
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene. Make sure to attach the GameManager script to an object in the scene.");
        }
    }

    void OnMouseDown()
    {
        // Check if the tile is already occupied
        if (IsOccupied())
        {
            Debug.LogWarning("Tile is already occupied. Choose another tile.");
            return;
        }

        // Check if GameManager has an equipped Cat prefab
        if (gameManager.HasEquippedCat)
        {
            // Inform the GameManager that the tile is clicked
            gameManager.OnTileClick(this);

            // Mark the tile as occupied
            SetOccupied(true);
            Debug.Log("Tile marked as occupied.");
        }
        else
        {
            Debug.LogWarning("No Cat prefab is equipped. Please select a Cat prefab first.");
        }
    }

    // Check if the tile is occupied
    bool IsOccupied()
    {
        return occupied;
    }

    // Set the occupied status of the tile
    public void SetOccupied(bool status)
    {
        occupied = status;
    }

    // Check if the tile is empty
    public bool IsEmpty()
    {
        return !occupied;
    }

    // Other tile-related methods...
}