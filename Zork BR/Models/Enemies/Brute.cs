using Zork_BR.Models.Enemies;
using Zork_BR.Models.Utility;

namespace Zork_BR.Repositories
{
    internal class Brute : Enemy
    {
        public override string Name => "Brute";
        public override int DamageToPlayer => Rng.Next(13, 20);


        private int hp = 50;

        public override int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                if (value < 0) hp = 0;
                else { hp = value; }
            }
        }
    }
}