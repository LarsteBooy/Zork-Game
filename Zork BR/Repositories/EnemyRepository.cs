using Zork_BR.Models;
using Zork_BR.Models.Enemies;
using Zork_BR.Models.Locations;
using Zork_BR.Models.Utility;

namespace Zork_BR.Repositories
{
    public class EnemyRepository
    {
        Player player = null;

        public EnemyRepository(Player player)
        {
            this.player = player;
        }

        public string SpawnEnemy()
        {
            Location location = player.CurrentLocation;

            int chanceToSpawnEnemy = Rng.Next(0, 100);

            if(chanceToSpawnEnemy < 60) //60% chance no enemy is spawned
            {
                return "";
            }

            player.CurrentLocation.Enemy = new CommonEnemy();

            player.InBattle = true;

            return string.Format("You see {0} and ask for help. Than you remember you are in a game and these are your enemies so you engage in combat." + MyStaticClass.WhiteLine(), player.CurrentLocation.Enemy.Name);
        }

        //TODO Juiste random enemy death calculator maken hier. Bijvoorbeeld dat er meer enemies tegelijk kunnen dood gaan en hoe minder enemies er zijn hoe minder kans dat er één dood gaat.
        public void RandomEnemyDeath()
        {
            int random = Rng.Next(0, 100);
            if(random <= 30) //30% chance to kill a random enemy
            {
                MyStaticClass.EnemiesRemaining--;
            }
        }
    }
}