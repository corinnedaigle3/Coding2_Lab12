using System;
using UnityEngine;
using System.Collections.Generic;

class InventoryManager : MonoBehaviour
{
    List<InventoryItem> inventoryItems = new List<InventoryItem>();

    private void Start()
    {
        InitializeInventory();
        PrintInventory();

        // Sort by ID before performing binary search
        inventoryItems.Sort((a, b) => a.itemId.CompareTo(b.itemId));

        Debug.Log("After sorting by ID:");
        PrintInventory();
    }

    public void InitializeInventory()
    {
        for (int i = 0; i < 5; i++)
        {
            string name = "Item " + i;
            float id = UnityEngine.Random.Range(0f, 100f); // Random ID
            float value = UnityEngine.Random.value;
            InventoryItem newItem = new InventoryItem(name, id, value);
            inventoryItems.Add(newItem);
        }
    }

    private void PrintInventory()
    {
        foreach (InventoryItem newItem in inventoryItems)
        {
            Debug.Log($"Name: {newItem.itemName}, ID: {newItem.itemId:F2}, Value: {newItem.itemValue:F2}");
        }
    }

    // Linear Search by Name
    public InventoryItem LinearSearchByName(string itemName)
    {
        foreach (InventoryItem newItem in inventoryItems)
        {
            if (newItem.itemName == itemName)
                return newItem;
        }
        return null;
    }

    // Binary Search by ID (works only on a sorted list)
    public InventoryItem BinarySearchByID(float targetId)
    {
        int left = 0;
        int right = inventoryItems.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            float midId = inventoryItems[mid].itemId;

            if (Mathf.Approximately(midId, targetId))
            {
                return inventoryItems[mid]; // Found match
            }
            else if (midId < targetId)
            {
                left = mid + 1; // Search right half
            }
            else
            {
                right = mid - 1; // Search left half
            }
        }

        return null; // Not found
    }
}
