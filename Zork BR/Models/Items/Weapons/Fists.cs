using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Items
{
    public class Fists : Weapon
    {
        public override string Name { get => "Fists"; }

        public override int Damage => Rng.Next(7,13);
    }
}