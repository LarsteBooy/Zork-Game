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
        private int currentHealth = 29;
        public int MaxHealth { get; set; } = 100;

        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string PlayerName { get; set; }
        public Weapon SelectedWeapon { get; set; } = new Fists();
        public bool InBattle { get; set; }
        public bool InEquipState { get; set; }
        public int Kills { get; set; }

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

        public Location CurrentLocation
        {
            get
            {
                return Map.map[YCoord, XCoord];
            }
        }
    }
}