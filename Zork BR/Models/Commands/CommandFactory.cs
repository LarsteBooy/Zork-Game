using System;

namespace Zork_BR.Models.Commands
{
    public class CommandFactory
    {
        public static Command Create(string input, Story story, Player player, PlayerStats playerStats)
        {
            Command result = null;
            if (Enum.TryParse(input, true, out Inputs commandType))
            {
                switch (commandType)
                {
                    case Inputs.Help: result = new HelpCommand();
                        break;
                    case Inputs.Render: result = new AdminCommand(input, playerStats);
                        break;
                    case Inputs.Status: result = new StatusCommand(player, playerStats);
                        break;
                    case Inputs.Bagspace:
                        result = new AdminCommand(input, playerStats);
                        break;
                    case Inputs.Loot: result = new LootCommand(input, player, playerStats);
                        break;
                    case Inputs.Inventory: result = new GetInventoryCommand(player, playerStats);
                        break;
                    case Inputs.Heal: result = new HealCommand(player);
                        break;
                    case Inputs.Equip: result = new EquipCommand(player, input);
                        break;
                    case Inputs.Drop: result = new DropCommand(player, input);
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
        Equip,
        Drop
    }
}