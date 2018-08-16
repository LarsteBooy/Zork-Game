using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                    case BattleInputs.Run: result = new RunCommand();
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
    }
}