using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ShopController : MonoBehaviour
{
    public GameObject listItemPrefab;
    public Transform contentPanel;

    private List<string> dataList; // Example data, replace with your own data structure

    void Start()
    {
        // Initialize data
        dataList = new List<string>();
        dataList.Add("Item 1");
        dataList.Add("Item 2");
        dataList.Add("Item 3");

        // Populate list
        PopulateList();
    }

    void PopulateList()
    {
        // Clear existing items
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Instantiate list items
        foreach (string data in dataList)
        {
            GameObject listItem = Instantiate(listItemPrefab, contentPanel);
            TextMeshProUGUI[] textMeshPros = listItem.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI textMeshPro in textMeshPros)
            {
                textMeshPro.text = data;
            }
            // Add any additional setup for list items here
        }
    }

    // Example method for adding a new item to the list
    public void AddItem(string newItem)
    {
        dataList.Add(newItem);
        PopulateList();
    }

    // Example method for removing an item from the list
    public void RemoveItem(string itemToRemove)
    {
        dataList.Remove(itemToRemove);
        PopulateList();
    }
}
