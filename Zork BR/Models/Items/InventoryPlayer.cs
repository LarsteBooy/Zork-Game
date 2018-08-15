using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork_BR.Models.Items
{
    public class InventoryPlayer
    {
        public ICollection<Item> Inventory { get; set; }
        public int NumberOfItems { get; set; }

        public InventoryPlayer()
        {
            Inventory = new List<Item>();
        }
        

        public void AddItem(Item item)
        {
                if(item is Binoculars)
                {
                    MyStaticClass.RenderMinimap = true;
                } 
                if(item is Backpack)
                {
                    MyStaticClass.MaximumItemsInInventory = 15;
                }

                Inventory.Add(item);
                NumberOfItems++;
                
            }
            
        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }


    }
}