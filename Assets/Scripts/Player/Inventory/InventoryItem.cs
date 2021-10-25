using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PPI.Player.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private string name = "";
        [SerializeField, TextArea] private string description = "";
        [SerializeField] private Sprite icon;

        [SerializeField] private UnityEvent OnUse;

        public Sprite Icon { get => icon; }

        public void UseItem()
        {
            OnUse.Invoke();
        }

        public void OnInteract(PlayerInventory inventory)
        {
            inventory.AddItem(this);
            gameObject.SetActive(false);
        }
    }
}
