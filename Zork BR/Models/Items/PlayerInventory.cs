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
        public int PlayerInventoryId { get; set; }
        
        public Player Player { get; set; }

        public ICollection<Item> Inventory { get; set; }
        public int NumberOfItems { get; set; }
        PlayerStats playerStats = null;

        public PlayerInventory(/*PlayerStats playerStats*/)
        {
            Inventory = new List<Item>();
            //this.playerStats = playerStats;
        }
        

        public void AddItem(Item item)
        {
                if(item is Binoculars)
                {
                    playerStats.RenderMinimap = true;
                } 
                if(item is Backpack)
                {
                    MyStaticClass.MaximumItemsInInventory = 13;
                }

                Inventory.Add(item);
                NumberOfItems++;
                
            }
            
        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);

            if (!Inventory.Any(x => x is Binoculars))
            {
                playerStats.RenderMinimap = false;
            }

            if (!Inventory.Any(x => x is Backpack))
            {
                MyStaticClass.MaximumItemsInInventory = 8;
            }

            NumberOfItems--;
        }
    }
}