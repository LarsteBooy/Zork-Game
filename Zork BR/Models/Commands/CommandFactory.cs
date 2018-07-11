using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public static class CommandFactory
    {
        public static Command Create(string input, int id)
        {
            Command result = null;
            if (Enum.TryParse(input, true, out Inputs commandType))
            {
                switch (commandType)
                {
                    case Inputs.Poke: result = new PokeCommand();
                        break;
                    case Inputs.Dance: result = new DanceCommand();
                        break;
                    case Inputs.North:
                    case Inputs.East:
                    case Inputs.South:
                    case Inputs.West:
                        result = new DirectionCommand(input, id);
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
        Poke,
        Dance,
        North,  
        East,
        South,
        West,
    }
}