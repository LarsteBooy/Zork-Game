using Zork_BR.Models;

namespace Zork_BR.ViewModels
{
    public class AfterGameViewModel
    {
        PlayerStats playerStats = null;

        public AfterGameViewModel(PlayerStats playerStats)
        {
            this.playerStats = playerStats;
        }

        public int Kills
        {
            get
            {
                return Kills = playerStats.Kills;
            }
            set { }
        }

        public int EnemiesRemaining
        {
            get
            {
                return EnemiesRemaining = playerStats.EnemiesRemaining;
            }
            set { }
        }


    }
}