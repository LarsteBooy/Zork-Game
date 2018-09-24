using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Items.Weapons
{
    public class Pistol : Weapon
    {
        public override string Name => "Pistol";

        public override int Damage => Rng.Next(25, 35);
    }
}