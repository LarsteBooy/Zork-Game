using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Zork_BR.Models.Items
{
    public class PlayerInventory
    {
        [Key, ForeignKey("Player")]
        public int Id { get; set; }
        
        public Player Player { get; set; }
        public PlayerStats PlayerStats { get; set; }

        public virtual ICollection<Item> Inventory { get; set; }
        public int NumberOfItems { get; set; }
        

        public PlayerInventory()
        {
            Inventory = new List<Item>();
        }



        public void AddItem(Item item)
        {
                if(item is Binoculars)
                {
                    PlayerStats.RenderMinimap = true;
                } 
                if(item is Backpack)
                {
                    PlayerStats.MaximumItemsInInventory = 13;
                }
                
                Inventory.Add(item);
                NumberOfItems++;
                
            }
            
        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);

            if (!Inventory.Any(x => x is Binoculars))
            {
                PlayerStats.RenderMinimap = false;
            }

            if (!Inventory.Any(x => x is Backpack))
            {
                if (Inventory.Count < PlayerStats.MaximumItemsInInventory)
                {
                    //TODO Maak dit af
                }
                PlayerStats.MaximumItemsInInventory = 8;
            }
            
            NumberOfItems--;
        }
        
        public IEnumerable<Item> Get<T>()
        {
            var availableWeapons = from item in Inventory
                                   where item is T
                                   orderby item.Name
                                   select item;

            return availableWeapons;
        }
    }
}