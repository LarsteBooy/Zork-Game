using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class AdminCommand : Command
    {
        private readonly string input;

        public AdminCommand(string input)
        {
            this.input = input;
        }

        public override string MyAction()
        {
            switch (input)
            {
                case "render": MyStaticClass.RenderMinimap = true;
                    break;
                case "bagspace": MyStaticClass.MaximumItemsInInventory = 15;
                    break;
            }

            return "";
        }
    }
}