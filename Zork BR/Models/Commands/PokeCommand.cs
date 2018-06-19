using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class PokeCommand : Command
    {
        public override void MyAction()
        {
            System.Diagnostics.Debug.WriteLine("This is a PokeCommand");
        }
    }
}