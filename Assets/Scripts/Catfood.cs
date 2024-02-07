using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catfood : MonoBehaviour
{
    public int catfoodValue = 10; // Adjust the amount of Catfood this prefab provides

    private void OnMouseDown()
    {
        CollectCatfood();
    }


    void CollectCatfood()
    {
        CatfoodBank catfoodBank = FindObjectOfType<CatfoodBank>();
        if (catfoodBank != null)
        {
            catfoodBank.AddCatfood(catfoodValue);
            Destroy(gameObject); // Remove the Catfood prefab after collecting
        }
    }
}