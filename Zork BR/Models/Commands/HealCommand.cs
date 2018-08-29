using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands
{
    public class HealCommand : Command
    {
        Player player = null;

        public HealCommand(Player player)
        {
            this.player = player;
        }

        public override string MyAction()
        {
            List<Item> availableHealthPotions = new List<Item>();
            
            foreach(Item item in Player.inventoryPlayer.Inventory)
            {
                if(item is HealthPotion)
                {
                    availableHealthPotions.Add(item);
                }
            }

            return "";
        }
    }
}