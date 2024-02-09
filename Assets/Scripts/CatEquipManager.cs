using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEquipManager : MonoBehaviour
{
    public GameObject[] catPrefabs; // Array to store different cat prefabs
    private GameObject selectedCatPrefab; // Currently selected cat prefab

    public void SelectCat(int catIndex)
    {
        if (catIndex >= 0 && catIndex < catPrefabs.Length)
        {
            selectedCatPrefab = catPrefabs[catIndex];
        }
        else
        {
            Debug.LogError("Invalid cat index");
        }
    }

    public GameObject GetSelectedCatPrefab()
    {
        return selectedCatPrefab;
    }
}