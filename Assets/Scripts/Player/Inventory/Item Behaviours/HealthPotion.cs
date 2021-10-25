using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.Player.Inventory
{
    public class HealthPotion : MonoBehaviour
    {
        [SerializeField] private int regenFactor = 10;
        [SerializeField] private PlayerStats stats = null;

        public void OnUse()
        {
            stats.ChangeHealth(regenFactor);
        }
    }
}
