using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] catPrefabs; // Assign Cat prefabs in the Inspector

    private GameObject equippedCatPrefab;
    public bool hasEquippedCat;

    public bool HasEquippedCat // Property to access the variable
    {
        get { return hasEquippedCat; }
    }

    public void OnTileClick(Tile tile)
    {
        PlaceCatOnTile(tile);
    }

    private void EquipCatPrefab(int catIndex)
    {
        equippedCatPrefab = catPrefabs[catIndex];
        hasEquippedCat = true; // Set the variable to true when a cat is equipped
        Debug.Log($"Equipped Cat Prefab: {equippedCatPrefab.name}");
    }

    // Called when a tile is clicked
    public void PlaceCatOnTile(Tile tile)
    {
        if (HasEquippedCat && equippedCatPrefab != null && tile.IsEmpty())
        {
            // Calculate the spawn position based on the angle and radius
            Vector3 spawnPosition = tile.transform.position + new Vector3(0f, 0.2f, 0f);

            // Calculate the rotation to add an angle on the X-axis
            Quaternion spawnRotation = Quaternion.Euler(45f, 0f, 0f); // Adjust the X-axis angle as needed

            // Instantiate the equipped cat prefab and place it on the tile
            GameObject catInstance = Instantiate(equippedCatPrefab, spawnPosition, spawnRotation);
            Debug.Log("Cat placed.");

            // Set the tile as occupied
            tile.SetOccupied(true);

            // Set the occupying tile for the Cat instance
            Cat catScript = catInstance.GetComponent<Cat>();
            if (catScript != null)
            {
                catScript.SetOccupyingTile(tile);
            }

            // Reset equipped cat information
            equippedCatPrefab = null;
            hasEquippedCat = false;
        }
    }

    private Tile GetTileAtPosition(Vector3 position)
    {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(position);

    if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has a Tile component
            Tile tile = hit.collider.GetComponent<Tile>();

            if (tile != null)
            {
                // Found a tile
                return tile;
            }
        }

        // No tile found at the given position
        return null;
    }


    public void OnCatDeath(Cat cat)
    {
        // Notify the tile that the cat on it has died
        if (cat != null && cat.GetComponent<Cat>() != null)
        {
            cat.GetComponent<Cat>().NotifyTileOnDeath();
        }
    }
}
