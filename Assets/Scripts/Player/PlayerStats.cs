using UnityEngine;

namespace PPI.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;

        private int currentHealth;

        public int MaxHealth { get => maxHealth; }
        public int CurrentHealth { get => currentHealth; }

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void ChangeHealth(int factor)
        {
            int diff = maxHealth - currentHealth;
            currentHealth += factor >= diff ? diff : factor;
        }
    }
}
