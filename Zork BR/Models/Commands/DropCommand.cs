using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class DropCommand : Command
    {
        Player player = null;
        readonly string input;

        public DropCommand(Player player, string input)
        {
            this.player = player;
            this.input = input.ToTitleCase();
        }

        public override string MyAction()
        {
            //Create list with all available weapons the player has
            List<Item> allItemsInInventory = new List<Item>();
            int itemCounter = 1;

            foreach (Item item in Player.inventoryPlayer.Inventory)
            {
                 allItemsInInventory.Add(item);
            }

            if (!player.InDropState)
            {
                string appendToStory = string.Format("Which ítem would you like to drop:{0}", Environment.NewLine);

                foreach (Item i in Player.inventoryPlayer.Inventory)
                {
                    appendToStory += Environment.NewLine + itemCounter + ". " + i.Name;
                    itemCounter++;
                }

                if (Player.inventoryPlayer.NumberOfItems <= 0)
                {
                    return "You don't have any items" + MyStaticClass.WhiteLine();
                }
                else
                {
                    player.InDropState = true;
                    return appendToStory + MyStaticClass.WhiteLine();
                }
            }

            string itemToBeDropped = string.Format("{0} is not a item you can drop {1}", input.ToTitleCase(), MyStaticClass.WhiteLine());
            bool itemDropped = false;

            foreach (Item item in allItemsInInventory)
            {
                if (item.Name.Equals(input) && !itemDropped)
                {
                    Player.inventoryPlayer.RemoveItem(item);
                    itemToBeDropped = string.Format("You dropped {0}", item.Name) + MyStaticClass.WhiteLine();
                    itemDropped = true;
                }
            }

            return itemToBeDropped;
        }
    }
}