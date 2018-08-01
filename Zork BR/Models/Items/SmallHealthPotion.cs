using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public class SmallHealthPotion : Consumable
    {
        public override string Name => "Small Health Potion";

        public override int MaximumStackableQuantity => 7;

        public override int HealthRegain => 30;
    }
}