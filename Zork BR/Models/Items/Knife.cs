using System;

namespace Zork_BR.Models.Items
{
    public class Knife : Weapon
    {
        public override string Name { get => "Knife"; set => this.Name = value; }

        public override void Attack()
        {
            throw new NotImplementedException();
            //
        }
    }
}