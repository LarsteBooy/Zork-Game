using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class AddBagspace : Command
    {
        public override string MyAction()
        {

            MyStaticClass.MaximumItemsInInventory += 2;
            return "";
        }
    }
}