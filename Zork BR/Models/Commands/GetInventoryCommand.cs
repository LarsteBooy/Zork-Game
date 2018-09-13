using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class GetInventoryCommand : Command
    {
        PlayerStats playerStats = null;

        public GetInventoryCommand(PlayerStats playerStats)
        {
            this.playerStats = playerStats;
        }

        public override string MyAction()
        {
            string appendToStory = string.Format("You can have a maximum number of {0} inventory slots. {1}You've got:{1}", playerStats.MaximumItemsInInventory, Environment.NewLine);
            int ocupiedInventorySpaces = 1;

            if(Player.inventoryPlayer.Inventory.Count == 0)
            {
                appendToStory += Environment.NewLine + "Nothing... it's good practice to have some items before looking through your inventory";
            }

            var sortedList = Player.inventoryPlayer.Inventory.OrderBy(x => x.Name);

            foreach (Item i in sortedList)
            {
                appendToStory += Environment.NewLine + ocupiedInventorySpaces + ". " + i.Name;
                ocupiedInventorySpaces++;
            }

            appendToStory += MyStaticClass.WhiteLine();

            return appendToStory;
        }
    }
}