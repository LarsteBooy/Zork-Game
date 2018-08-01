using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public abstract class Consumable : Item
    {
        public virtual int HealthRegain { get;}
    }
}