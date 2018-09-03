using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class CommandFactory
    {
        public static Command Create(string input, Story story, Player player)
        {
            Command result = null;
            if (Enum.TryParse(input, true, out Inputs commandType))
            {
                switch (commandType)
                {
                    case Inputs.Help: result = new HelpCommand(story);
                        break;
                    case Inputs.Render: result = new AdminCommand(input);
                        break;
                    case Inputs.Status: result = new StatusCommand(player);
                        break;
                    case Inputs.Bagspace:
                        result = new AdminCommand(input);
                        break;
                    case Inputs.Loot: result = new LootCommand(input, story, player);
                        break;
                    case Inputs.Inventory: result = new GetInventoryCommand();
                        break;
                    case Inputs.Heal: result = new HealCommand(player);
                        break;
                    case Inputs.Equip: result = new EquipCommand(player, input);
                        break;
                    case Inputs.North:
                    case Inputs.East:
                    case Inputs.South:
                    case Inputs.West:
                        result = new DirectionCommand(input, story, player);
                        break;
                }
                return result;
            }
            else
            {
                return null;
            }
        }
    }

    public enum Inputs
    {
        North,  
        East,
        South,
        West,
        Help,
        Render,
        Loot,
        Inventory,
        Bagspace,
        Status,
        Heal,
        Equip
    }
}