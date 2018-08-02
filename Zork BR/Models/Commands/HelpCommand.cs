using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class HelpCommand : Command
    {
        readonly Story story = null;

        private string helpText;

        public HelpCommand(Story story)
        {
            this.story = story;
        }

        public override string MyAction()
        {
           helpText = "    Commands" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine +
                      "    [Movement]"+ Environment.NewLine +
                      "--------------------" + Environment.NewLine + 
                      "North - Move North" + Environment.NewLine + 
                      "West - Move West" + Environment.NewLine + 
                      "South - Move South" + Environment.NewLine + 
                      "East - Move East" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine + 
                      "  [Items / Actions]" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine + 
                      " - Equip" + Environment.NewLine + 
                      " - Attack" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine + 
                      "  [Fun commands]" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine + 
                      " - Secret" + MyStaticVars.WhiteLine();

           return helpText;
        }
    }
}
