using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items
{
    public class Knife : Weapon
    {
        public override string Name { get => "Knife"; }

        public override void Attack()
        {
            throw new NotImplementedException();
            //
        }
    }
}