using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public class HealthPotion : Consumable
    {
        public override string Name => "Health Potion";

        public override int MaximumStackableQuantity => 5;

        public override int HealthRegain => 50;
    }
}