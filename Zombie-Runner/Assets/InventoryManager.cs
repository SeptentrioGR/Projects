using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{

    public Dictionary<string, Item> Items = new Dictionary<string, Item>();

    public bool AquireItem(string itemName)
    {

        if (Items.ContainsKey(itemName))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void AddItem(string itemName, Item item)
    {
        if (Items.ContainsKey(itemName))
        {
            Debug.Log("Item Already Exist ");
        } else
        {
            Items.Add(itemName, item);
        }

    }

    public void RemoveItem(string itemName)
    {
        if (Items.ContainsKey(itemName))
        {
            Items.Remove(itemName);
        } else
        {
            Debug.Log("Item Removed ");
        }
    }
}
