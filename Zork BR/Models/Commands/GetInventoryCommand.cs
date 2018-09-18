using System;
using System.Linq;

namespace Zork_BR.Models.Commands
{
    public class GetInventoryCommand : Command
    {
        Player player = null;
        PlayerStats playerStats = null;

        public GetInventoryCommand(Player player, PlayerStats playerStats)
        {
            this.player = player;
            this.playerStats = playerStats;
        }

        public override string MyAction()
        {
            string appendToStory = string.Format("You can have a maximum number of {0} inventory slots. {1}You've got:{1}", playerStats.MaximumItemsInInventory, Environment.NewLine);
            int ocupiedInventorySpaces = 1;

            if(player.PlayerInventorySystem.Inventory.Count == 0)
            {
                appendToStory += Environment.NewLine + "Nothing... it's good practice to have some items before looking through your inventory";
            }

            var sortedList = player.PlayerInventorySystem.Inventory.OrderBy(x => x.Name);

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