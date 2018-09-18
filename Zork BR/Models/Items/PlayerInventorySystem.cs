using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Zork_BR.Models.Items
{
    public class PlayerInventorySystem
    {
        [Key, ForeignKey("Player")]
        public int Id { get; set; }
        
        public Player Player { get; set; }
        public PlayerStats PlayerStats { get; set; }

        public virtual ICollection<Item> Inventory { get; set; }
        public int NumberOfItems { get; set; }

        public PlayerInventorySystem()
        {
            Inventory = new List<Item>();
        }

        public void AddItem(Item item)
        {
                Inventory.Add(item);
                NumberOfItems++;

                if(item is Binoculars)
                {
                    PlayerStats.RenderMinimap = true;
                } 
                if(item is Backpack)
                {
                    PlayerStats.MaximumItemsInInventory = MyStaticClass.MaxItemsInInventoryWithBackpack;
                }
            }
            
        public string RemoveItem(Item item)
        {
            Inventory.Remove(item);
            NumberOfItems--;

            //if there are no more binoculars in inventory 
            if (!Inventory.Any(x => x is Binoculars))
            {
                PlayerStats.RenderMinimap = false;
            }

            //if there are no more backpacks in inventory
            if (!Inventory.Any(x => x is Backpack))
            {
                PlayerStats.MaximumItemsInInventory = MyStaticClass.MaxItemsInInventoryDefault;

                //if item that was removed is last backpack in inventory
                if (item is Backpack && Inventory.Count() > PlayerStats.MaximumItemsInInventory)
                {
                    Inventory.Add(item);
                    NumberOfItems++;
                    PlayerStats.MaximumItemsInInventory = MyStaticClass.MaxItemsInInventoryWithBackpack;
                    return string.Format("You can't drop the {0} right now because you can't hold all your items otherwise", item.Name);
                }
            }

            return string.Format("You dropped the {0}", item.Name);
        }


        
        public IEnumerable<Item> Get<T>()
        {
            var availableItems = from item in Inventory
                                   where item is T
                                   orderby item.Name
                                   select item;

            return availableItems;
        }
    }
}