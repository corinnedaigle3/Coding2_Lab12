using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public float itemId;
    public string itemName;
    public float itemValue;

    public InventoryItem(string name, float id, float value)
    {
        itemId = id;
        itemName = name;
        itemValue = value;
    }

}
