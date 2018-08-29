using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Enemies
{
    public class CommonEnemy : Enemy
    {
        public override string Name => "Common Enemy";
        public override int DamageToPlayer => Rng.Next(7, 13);

        private int hp = 30;

        public override int Hp {
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