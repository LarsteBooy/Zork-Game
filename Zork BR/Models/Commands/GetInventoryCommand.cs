using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class GetInventoryCommand : Command
    {
        public override string MyAction()
        {
            string appendToStory = "You have:" + Environment.NewLine;

            if(Player.inventoryPlayer.Inventory.Count == 0)
            {
                appendToStory += Environment.NewLine + "Nothing... it's good practice to have some items before looking through your inventory";
            }

            foreach (Item i in Player.inventoryPlayer.Inventory)
            {
                appendToStory += Environment.NewLine + i.Name;
            }

            appendToStory += MyStaticClass.WhiteLine();

            return appendToStory;
        }
    }
}