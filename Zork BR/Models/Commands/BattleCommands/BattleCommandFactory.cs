using System;
using Zork_BR.Models.Commands.BattleCommands;

namespace Zork_BR.Models.Commands
{
    public class BattleCommandFactory
    {
        public static Command Create(string input, Story story, Player player)
        {
            Command result = null;
            if (Enum.TryParse(input, true, out BattleInputs commandType))
            {
                switch (commandType)
                {
                    case BattleInputs.Run: result = new RunCommand(player);
                        break;
                    case BattleInputs.Attack: result = new AttackCommand(player);
                        break;
                    case BattleInputs.Status: result = new StatusCommand(player);
                        break;
                    case BattleInputs.Help: result = new HelpCommand();
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

    public enum BattleInputs
    {
        Run,
        Attack,
        Status,
        Help
    }
}