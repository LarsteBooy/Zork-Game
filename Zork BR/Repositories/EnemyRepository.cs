using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (chanceToSpawnEnemy < 40)//40% to spawn a Enemy
            {
                //TODO spawn hier enemy

                using (var context = ApplicationDbContext.Create())
                {
                    CommonEnemy commonEnemy = new CommonEnemy();
                    context.Enemies.Add(commonEnemy);

                    context.SaveChanges();
                }

                MyStaticClass.InBattle = true;
                return "You see someone and ask for help. Than you remember you are in a game and these are your enemies so you engage in combat." + MyStaticClass.WhiteLine();
            }

            return "";
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