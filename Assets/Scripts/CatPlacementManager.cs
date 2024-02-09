using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlacementManager : MonoBehaviour
{
    public GameObject catPrefab;
    public Vector3 cat1Position = new Vector3(-2f, 0f, 0f);

    public void PlaceCat(Tile tile, GameObject catPrefab)
    {
        if (tile.occupiedCat == null)
        {
            // Place the cat on the tile if it's not already occupied
            GameObject cat = Instantiate(catPrefab, tile.transform.position, Quaternion.identity);
            tile.occupiedCat = cat;
        }
        else
        {
            Debug.Log("Tile is already occupied!");
        }
    }
}