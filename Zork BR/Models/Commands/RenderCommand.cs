using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.ViewModels;

namespace Zork_BR.Models.Commands
{
    public class RenderCommand : Command
    {
        public override string MyAction()
        {
            MyStaticClass.RenderMinimap = true;
            return "";
        }
    }
}