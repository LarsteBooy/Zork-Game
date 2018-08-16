using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Enemies
{
    public abstract class Enemy
    {
        public abstract string Name { get;}
        public abstract int DamageToPlayer { get;}
        public abstract int Hp { get; set; }

        public bool IsDead {
            get { return IsDead; }
            set {
                if (Hp <= 0)
                {
                    IsDead = true;
                }
            }
        }
    }
}