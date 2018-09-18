using System;
using System.Collections.Generic;
using System.Linq;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands
{
    public class DropCommand : Command
    {
        Player player = null;
        readonly PlayerStats playerStats = null;
        readonly string input;
        

        public DropCommand(Player player, PlayerStats playerStats, string input)
        {
            this.player = player;
            this.playerStats = playerStats;
            this.input = input.ToTitleCase();
        }

        

        public override string MyAction()
        {
            
            var inventorySystem = player.PlayerInventorySystem;

            //Create list with all available items the player has
            var allItemsInInventory = inventorySystem.Get<Item>();

            int itemCounter = 1;
            
            if (!player.InDropState)
            {
                string appendToStory = string.Format("Which ítem would you like to drop:{0}", Environment.NewLine);
                
                foreach (Item i in allItemsInInventory)
                {
                    appendToStory += Environment.NewLine + itemCounter + ". " + i.Name;
                    itemCounter++;
                }

                if (inventorySystem.NumberOfItems <= 0)
                {
                    return "You don't have any items" + MyStaticClass.WhiteLine();
                }
                else
                {
                    player.InDropState = true;
                    return appendToStory + MyStaticClass.WhiteLine();
                }
            }

            string appendToStory2 = string.Format("{0} is not a item you can drop", input.ToTitleCase());
            bool foundItem = false;

            foreach (Item item in allItemsInInventory)
            {
                if (item.Name.Equals(input) && !foundItem)
                {
                    appendToStory2 = player.PlayerInventorySystem.RemoveItem(item);
                    
                    foundItem = true;
                }
            }

            return appendToStory2 + MyStaticClass.WhiteLine();
        }
    }
}