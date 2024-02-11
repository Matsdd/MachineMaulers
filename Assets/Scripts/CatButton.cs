using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatButton : MonoBehaviour
{
    public int catIndex; // Assign unique index for each button in the Inspector
    public CatEquipManager catEquipManager;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectCat);
    }

    void SelectCat()
    {
        Debug.Log("Cat selected.");
        catEquipManager.SelectCat(catIndex);
    }
}
