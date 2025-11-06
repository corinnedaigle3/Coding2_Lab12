using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

class InventoryManager : MonoBehaviour
{
    List<InventoryItem> inventoryItems = new List<InventoryItem>();

    private void Start()
    {
        InitializeInventory();
        PrintInventory(); //show items in the Console when game starts
    }

    public void InitializeInventory()
    {
        for (int i = 0; i < 3; i++)
        {
            string name = "Item " + i;
            float id = UnityEngine.Random.value;
            float value = UnityEngine.Random.value;
            InventoryItem newItem = new InventoryItem(name, id, value);
            inventoryItems.Add(newItem);
        }
    }

    private void PrintInventory()
    {
        Debug.Log($"Inventory contains {inventoryItems.Count} items:");

        foreach (InventoryItem newItem in inventoryItems)
        {
            Debug.Log(newItem); //calls ToString() automatically
        }
    }

    // Linear Search Method
     public InventoryItem LinearSearch(string itemName)
     {
         foreach (InventoryItem newItem in inventoryItems)
         {
             if (itemName == newItem)
             {
                 return newItem; // Return the index if the target is found
             }
         }
         return null; // Return -1 if the target is not found
     }

     static void Main()
     {
         // Example Usage
         int[] numbers = { 10, 25, 30, 45, 50, 65, 80 };
         int target = 45;

         int result = LinearSearch(numbers, target);

         // Print the result
         if (result != -1)
         {
             Console.WriteLine($"Target value {target} found at index {result}");
         }
         else
         {
             Console.WriteLine($"Target value {target} not found in the array");
         }
     }

    /* public InventoryItem BinarySearch(int[] arr, int target)
     {
         int left = 0;
         int right = arr.Length - 1;

         while (left <= right)
         {
             int mid = left + (right - left) / 2;

             if (arr[mid] == target)
             {
                 return mid; // Return the index if the target is found
             }
             else if (arr[mid] < target)
             {
                 left = mid + 1; // Narrow the search to the upper half
             }
             else
             {
                 right = mid - 1; // Narrow the search to the lower half
             }
         }

         return -1; // Return -1 if the target is not found
     }*/
}