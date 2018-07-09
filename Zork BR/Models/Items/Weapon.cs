using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public abstract class Weapon : Item
    {
        public int Strength { get; set; }

        public abstract void Attack();

    }
}