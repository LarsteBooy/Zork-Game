namespace Zork_BR.Models.Enemies
{
    public class CommonEnemy : Enemy
    {
        public override string Name => "Common Enemy";
        public override int DamageToPlayer => 10;

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