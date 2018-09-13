using Zork_BR.Models;

namespace Zork_BR.ViewModels
{
    public class AfterGameViewModel
    {
        Player player = null;

        public AfterGameViewModel(Player player)
        {
            this.player = player;
        }

        public int Kills
        {
            get
            {
                return Kills = player.Kills;
            }
            set { }
        }

        public int EnemiesRemaining
        {
            get
            {
                return EnemiesRemaining = MyStaticClass.EnemiesRemaining;
            }
            set { }
        }


    }
}