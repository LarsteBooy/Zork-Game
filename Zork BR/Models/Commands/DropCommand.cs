using System;
using System.Collections.Generic;
using System.Linq;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands
{
    public class DropCommand : Command
    {
        Player player = null;
        PlayerStats playerStats = null;
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

            string appendToStory2 = string.Format("{0} is not a item you can drop {1}", input.ToTitleCase(), MyStaticClass.WhiteLine());
            bool foundItem = false;

            foreach (Item item in allItemsInInventory)
            {
                if (item.Name.Equals(input) && !foundItem)
                {
                    player.PlayerInventorySystem.RemoveItem(item);

                    //if there are no more binoculars in inventory 
                    if (!inventorySystem.Inventory.Any(x => x is Binoculars))
                    {
                        playerStats.RenderMinimap = false;
                    }

                    //if there are no more backpacks in inventory
                    if (!inventorySystem.Inventory.Any(x => x is Backpack))
                    {
                        playerStats.MaximumItemsInInventory = 8;

                        //if item that was dropped is last backpack in inventory
                        if (item is Backpack && inventorySystem.Inventory.Count() > playerStats.MaximumItemsInInventory)
                        {
                            inventorySystem.Inventory.Add(item);
                            inventorySystem.NumberOfItems++;
                            playerStats.MaximumItemsInInventory = 13;
                            return string.Format("You can't drop the {0} right now {1} because you can't hold all your items otherwise{2}", item.Name, player.PlayerInventorySystem.WhyIsDropUnsuccesfull, MyStaticClass.WhiteLine());
                        }
                    }
                    
                    appendToStory2 = string.Format("You dropped the {0}", item.Name);
                    
                    
                    foundItem = true;
                }
            }

            return appendToStory2 + MyStaticClass.WhiteLine();
        }
    }
}