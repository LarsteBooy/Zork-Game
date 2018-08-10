﻿using System;
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
        

        public string AddItem(Item item)
        {
            if(NumberOfItems < MyStaticClass.MaximumItemsInInventory)
            {
                //TODO If item == Binoculars MyStaticClass.Render = true
                //TODO if item == Backpack MyStaticClass.MaximumItemsInInventory += 5
                Inventory.Add(item);
                NumberOfItems++;
                return String.Format("You found a {0}" + MyStaticClass.WhiteLine(), item.Name);
            }
            else
            {
                return "Your inventory is full. To take this item remove something from your inventory" + MyStaticClass.WhiteLine();
            }
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }


    }
}