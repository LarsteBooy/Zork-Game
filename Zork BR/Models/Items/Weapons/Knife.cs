using System;

namespace Zork_BR.Models.Items
{
    public class Knife : Weapon
    {
        public override string Name { get => "Knife"; }

        public override int Damage => 20;
    }
}