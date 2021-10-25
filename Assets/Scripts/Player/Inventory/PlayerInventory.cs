using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.Player.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<InventoryItem> inventory = new List<InventoryItem>(4);

        public List<InventoryItem> Items { get => inventory; }

        public void AddItem(InventoryItem item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(int position)
        {
            inventory.RemoveAt(position);
        }
    }
}
