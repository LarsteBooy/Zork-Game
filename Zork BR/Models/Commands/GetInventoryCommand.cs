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
            string appendToStory = "You have:" + MyStaticClass.WhiteLine();

            if(Player.inventoryPlayer.Inventory.Count == 0)
            {
                appendToStory += "Nothing... it's good practice to have some items before looking through your inventory";
            }

            //Player.inventoryPlayer.Inventory.OrderBy(i => i.Name);

            foreach (Item i in Player.inventoryPlayer.Inventory)
            {
                appendToStory += i.Name + Environment.NewLine;
            }

            appendToStory += MyStaticClass.WhiteLine();

            return appendToStory;
        }
    }
}