using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public class Backpack : Item
    {
        public override string Name { get => "Backpack"; set => this.Name = value; }
    }
}