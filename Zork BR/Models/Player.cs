using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Zork_BR.Models.Items;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public InventoryPlayer inventoryPlayer;
        private int currentHealth;
        private int maxHealth = 100;
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string PlayerName { get; set; }
        //private ICollection<Item> Inventory { get; set; }
        private Weapon SelectedWeapon { get; set; }

        public int CurrentHealth
        {
            get { return currentHealth; }
            set
            {
                if (value < 0) currentHealth = 0;
                else if (value > maxHealth) currentHealth = MaxHealth;
                else { currentHealth = value; }
            }
        }

        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
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