using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Enemies
{
    public abstract class Enemy
    {
        public abstract int CurrentHP { get; set; }
        public abstract int Damage{ get; set; }
        public abstract List<Item> Loot { get; set; }
    }
}