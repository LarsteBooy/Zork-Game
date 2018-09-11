using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class HelpCommand : Command
    {
        private string helpText;
        
        public override string MyAction()
        {
           helpText = "      Commands" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine +
                      "     [Movement]"+ Environment.NewLine +
                      "--------------------" + Environment.NewLine + 
                      "North - Move North" + Environment.NewLine + 
                      "West - Move West" + Environment.NewLine + 
                      "South - Move South" + Environment.NewLine + 
                      "East - Move East" + Environment.NewLine +
                      "--------------------" + Environment.NewLine +
                      " [Overal Commands]" + Environment.NewLine +
                      "--------------------" + Environment.NewLine +
                      " - Help - Get commandlist" + Environment.NewLine +
                      " - Status - Get your status" + Environment.NewLine +
                      "--------------------" + Environment.NewLine + 
                      " [Items / Actions]" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine + 
                      " - Equip - Equip a weapon" + Environment.NewLine + 
                      " - Drop - Drop an item" + Environment.NewLine + 
                      " - Heal - Heal with best potion available" + Environment.NewLine +
                      " - Inventory - Get your inventory" + Environment.NewLine +
                      " - Loot - Loot tile" + Environment.NewLine +
                      "--------------------" + Environment.NewLine +
                      " [Battle Commands]" + Environment.NewLine +
                      "--------------------" + Environment.NewLine +
                      " - Attack - Attack enemy" + Environment.NewLine +
                      " - Run - Run from battle" + Environment.NewLine +
                      "--------------------" + Environment.NewLine + 
                      "   [Fun commands]" + Environment.NewLine + 
                      "--------------------" + Environment.NewLine + 
                      " - Secret" + MyStaticClass.WhiteLine();

           return helpText;
        }
    }
}
