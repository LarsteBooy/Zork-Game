using System;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Items
{
    public class Knife : Weapon
    {

        public override string Name { get => "Knife"; }

        public override int Damage => Rng.Next(15,25);
    }
}