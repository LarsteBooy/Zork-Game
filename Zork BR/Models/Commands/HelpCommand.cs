using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class HelpCommand : Command
    {
        Story story = null;

        private string helpText;
        private readonly int id = 0;

        public HelpCommand(int id, Story story)
        {
            this.id = id;
            this.story = story;
        }

        public override string MyAction()
        {
           helpText = "    Commands\n--------------------\n    [Movement]\n--------------------\nNorth - Move North\nWest - Move West\nSouth - Move South\nEast - Move East\n--------------------\n  [Items / Actions]\n--------------------\nEquip\nAttack\n--------------------\n  [Fun commands]\n--------------------\n - Dance\n - Poke\n - More\n====================\n";

           return helpText;
        }
    }
}
