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
        Debug.Log("GameManager received OnTileClick from Tile.");
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
            // Instantiate the equipped cat prefab and place it on the tile
            GameObject catInstance = Instantiate(equippedCatPrefab, tile.transform.position, Quaternion.identity);

            // Set the tile as occupied
            tile.SetOccupied(true);

            // Reset equipped cat information
            equippedCatPrefab = null;
            hasEquippedCat = false;
        }
    }
}
