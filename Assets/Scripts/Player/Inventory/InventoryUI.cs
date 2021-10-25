using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PPI.Player.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [System.Serializable]
        public struct ItemUI
        {
            public Image image;
            public Button useButton;
            public Text description;
        }

        [SerializeField] private KeyCode openInventoryBtn = KeyCode.Z;
        [SerializeField] private GameObject inventoryMenu = null;
        [SerializeField] private PlayerInventory inventory = null;
        [SerializeField] private List<ItemUI> items = new List<ItemUI>();
        [SerializeField] private Sprite emptyIcon;

        private int previousSize, currentSize;
        private bool active = false;

        private void Start()
        {
            previousSize = inventory.Items.Count;

            for (int i = 0; i < items.Count; ++i)
            {
                items[i].image.sprite = emptyIcon;
            }
        }

        private void Update()
        {
            currentSize = inventory.Items.Count;

            if (currentSize != previousSize)
            {
                for (int i = 0; i < currentSize; ++i)
                {
                    items[i].image.sprite = inventory.Items[i].Icon;
                }

                if (currentSize < items.Count - 1)
                {
                    for (int i = currentSize; i < items.Count; ++i)
                    {
                        items[i].image.sprite = emptyIcon;
                    }
                }
            }

            if (Input.GetKeyDown(openInventoryBtn))
            {
                inventoryMenu.SetActive(!active);
                active = !active;
            }

            previousSize = currentSize;
        }
    }
}
