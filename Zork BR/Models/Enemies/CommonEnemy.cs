using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Utility;

namespace Zork_BR.Models.Enemies
{
    public class CommonEnemy : Enemy
    {
         public override int CurrentHP
        {
            get
            {
                var FullHealth = Rng.Next(0, 1);
                if(FullHealth == 0)
                {
                    return CurrentHP = 100;
                }
                else
                {
                    return CurrentHP = Rng.Next(10, 100);
                } 
            }
            set {}
        }

        public override int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override List<Item> Loot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


    }
}