using Zork_BR.Models;

namespace Zork_BR.ViewModels
{
    public class GameOverViewModel
    {
        Player player = null;

        public GameOverViewModel(Player player)
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