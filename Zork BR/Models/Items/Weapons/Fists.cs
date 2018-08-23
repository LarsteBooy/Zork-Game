using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public class Fists : Weapon
    {
        public override string Name { get => "Fists"; }

        public override int Damage => 10;
    }
}