using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClickHandler : MonoBehaviour
{
    public CatEquipManager catEquipManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Tile clickedTile = hit.transform.GetComponent<Tile>();
                if (clickedTile != null)
                {
                    // Get the selected cat prefab from CatEquipManager
                    GameObject selectedCatPrefab = catEquipManager.GetSelectedCatPrefab();

                    // Instantiate the selected cat prefab on the clicked tile
                    if (selectedCatPrefab != null)
                    {
                        Instantiate(selectedCatPrefab, clickedTile.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Debug.LogError("No cat prefab selected");
                    }
                }
            }
        }
    }
}