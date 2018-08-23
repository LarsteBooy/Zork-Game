using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public class HealthPotion : Item, IHealthRegain
    {
        public override string Name { get ; }
        public int HealthRegain { get; set; }

        public HealthPotion(string name, int healthRegain)
        {
            this.Name = name;
            this.HealthRegain = healthRegain;
        }

    }
}