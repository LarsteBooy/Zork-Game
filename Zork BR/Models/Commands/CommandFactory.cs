using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class CommandFactory
    {
        Story story = null;
        Player player = null;

        public CommandFactory(Story story, Player player)
        {
            this.story = story;
            this.player = player;
        }
        public static Command Create(string input, int id)
        {
            Command result = null;
            if (Enum.TryParse(input, true, out Inputs commandType))
            {
                switch (commandType)
                {
                    case Inputs.Help: result = new HelpCommand(id, story);
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
        North,  
        East,
        South,
        West,
        Help,
    }
}