using System.ComponentModel.DataAnnotations;
using Zork_BR.Models.Items;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public static InventoryPlayer inventoryPlayer = new InventoryPlayer();
        private int currentHealth;

        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string PlayerName { get; set; }
        private Weapon SelectedWeapon { get; set; }
        

        public int CurrentHealth
        {
            get { return currentHealth; }
            set
            {
                if (value < 0) currentHealth = 0;
                else if (value > MaxHealth) currentHealth = MaxHealth;
                else { currentHealth = value; }
            }
        }

        public int MaxHealth { get; set; } = 100;

        public Location CurrentLocation
        {
            get
            {
                return Map.map[YCoord, XCoord];
            }
        }
    }
}