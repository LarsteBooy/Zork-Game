using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items.Consumables
{
    public abstract class HealthPotion : Item, IHealthRegain
    {
        public abstract int HealthRegain { get; }
    }
}