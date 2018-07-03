using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class DirectionCommand : Command
    {
        private string input;

        public DirectionCommand(string input)
        {
            this.input = input;
        }

        public override void MyAction()
        {
            System.Diagnostics.Debug.WriteLine("This is a DirectionCommand");
        }


    }
}