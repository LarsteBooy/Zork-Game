using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zork_BR.Models.Items;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public static InventoryPlayer inventoryPlayer = new InventoryPlayer();
        private int currentHealth = 100;
        public int MaxHealth { get; set; } = 100;

        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string PlayerName { get; set; }
        
        public bool InBattle { get; set; }
        public bool InEquipState { get; set; }
        public bool InDropState { get; set; }

        public int Kills { get; set; }

        [NotMapped]
        private Weapon _selectedWeapon;

        [NotMapped]
        public Weapon SelectedWeapon
        {
            get
            {
                if (_selectedWeapon == null)
                {
                    var type = Type.GetType(WeaponName);
                    if (type == null)
                    {
                        //what to do now?
                    }
                    _selectedWeapon = Activator.CreateInstance(type) as Weapon;
                    if (_selectedWeapon == null)
                    {
                        //it's not a weapon? :o
                    }
                }
                return _selectedWeapon;
            }
            set
            {
                _selectedWeapon = value;
                WeaponName = value.GetType().FullName;
            }
        }

        public string WeaponName { get; set; }

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

        private Player()
        {

        }

        public Player(Weapon weapon)
        {
            this.SelectedWeapon = weapon;
        }
    }
}