using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{

    public enum ItemElement
    {
        Flashlght, Radio
    }


    public class InventoryManager
    {
        public static InventoryManager instance;

        public static InventoryManager Instance
        {
            get
            {
                return instance;
            }
        }
        public InventoryManager()
        {
            instance = this;
        }

        private List<string> m_ItemIds = new List<string>();

        public bool HasItem(string itemName)
        {

            if (m_ItemIds.Contains(itemName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddItem(string itemName)
        {
            if (m_ItemIds.Contains(itemName))
            {
                Debug.Log("Item Already Exist ");
            }
            else
            {
                m_ItemIds.Add(itemName);
            }

        }

        public void RemoveItem(string itemName)
        {
            if (m_ItemIds.Contains(itemName))
            {
                m_ItemIds.Remove(itemName);
            }
            else
            {
                Debug.Log("Item not found ");
            }
        }
    }
}
