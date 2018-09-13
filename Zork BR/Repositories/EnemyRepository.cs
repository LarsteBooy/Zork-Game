using Zork_BR.Models;
using Zork_BR.Models.Enemies;
using Zork_BR.Models.Locations;
using Zork_BR.Models.Utility;

namespace Zork_BR.Repositories
{
    public class EnemyRepository
    {
        Player player = null;
        PlayerStats playerStats = null;

        public EnemyRepository(Player player, PlayerStats playerStats)
        {
            this.player = player;
            this.playerStats = playerStats;
        }

        string appendToStory = "No enemies in sight" + MyStaticClass.WhiteLine();

        private void ChanceToSpawnEnemy(int chanceToSpawn)
        {
            int random = Rng.Next(0, 100);
            int whichEnemy = Rng.Next(0, 100);
            Enemy enemy = null;

            if (random > chanceToSpawn)
            {
                appendToStory = "No enemies in sight" + MyStaticClass.WhiteLine();
            }
            else
            { 
                if(playerStats.EnemiesRemaining > 70)
                {
                    enemy = new Regular();
                }
                else if (playerStats.EnemiesRemaining > 40)
                {
                    if(whichEnemy < 50) { enemy = new Regular(); }
                    else { enemy = new Brute(); }
                }
                else if(playerStats.EnemiesRemaining > 10)
                {
                    if(whichEnemy < 30) { enemy = new Regular(); }
                    else { enemy = new Brute(); }
                }
                else
                {
                    if(whichEnemy < 10) { enemy = new Regular(); }
                    else { enemy = new Brute(); }
                }

                player.CurrentLocation.Enemy = enemy;
                player.InBattle = true;
                appendToStory = string.Format("You see a {0} and ask for help. Than you remember you are in a game and these are your enemies so you engage in combat. {1}", player.CurrentLocation.Enemy.Name, MyStaticClass.WhiteLine());
            }
        }

        public string SpawnEnemy()
        {
            Location location = player.CurrentLocation;

            if(playerStats.EnemiesRemaining > 70) //If there are more than 70 enemies remaining
            {
                ChanceToSpawnEnemy(60);
            }
            else if (playerStats.EnemiesRemaining > 40) //if there are more than 40 enemies and less than 70
            {
                ChanceToSpawnEnemy(40);
            }
            else if (playerStats.EnemiesRemaining > 10) //if there are more than 10 enemies and less than 40
            {
                ChanceToSpawnEnemy(20);
            }
            else //if there are 10 or less enmies remaining
            {
                ChanceToSpawnEnemy(5);
            }

            return appendToStory;
        }

        public void RandomEnemyDeath()
        {

            if(playerStats.EnemiesRemaining > 80) //Executes when there are more than 80 enemies remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if(chanceToDie < 65) //65% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if(howManyDeath < 50) //50% 1 enemy dies
                    {
                        playerStats.EnemiesRemaining--;
                    }
                    else if(howManyDeath >= 50 && howManyDeath < 86) //35% chance 2 enemies die
                    {
                        playerStats.EnemiesRemaining -= 2;
                    }
                    else //15% chance 3 enemies die
                    {
                        playerStats.EnemiesRemaining -= 3;
                    }
                }
            }

            if(playerStats.EnemiesRemaining > 60 && playerStats.EnemiesRemaining <= 80) //Executes when there are more than 60 enemies and less than 80 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 35) //35% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if (howManyDeath < 65) //65% 1 enemy dies
                    {
                        playerStats.EnemiesRemaining--;
                    }
                    else if (howManyDeath >= 65 && howManyDeath < 96) //30% chance 2 enemies die
                    {
                        playerStats.EnemiesRemaining -= 2;
                    }
                    else //5% chance 3 enemies die
                    {
                        playerStats.EnemiesRemaining -= 3;
                    }
                }
            }

            if (playerStats.EnemiesRemaining > 40 && playerStats.EnemiesRemaining <= 60) //Executes when there are more than 40 enemies and less than 60 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 20) //20% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if (howManyDeath < 80) //80% 1 enemy dies
                    {
                        playerStats.EnemiesRemaining--;
                    }
                    else if (howManyDeath >= 80 && howManyDeath < 100) //19% chance 2 enemies die
                    {
                        playerStats.EnemiesRemaining -= 2;
                    }
                    else //1% chance 3 enemies die
                    {
                        playerStats.EnemiesRemaining -= 3;
                    }
                }
            }

            if (playerStats.EnemiesRemaining > 10 && playerStats.EnemiesRemaining <= 40) //Executes when there are more than 10 enemies and less than 40 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 10) //10% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if (howManyDeath < 94) //94% 1 enemy dies
                    {
                        playerStats.EnemiesRemaining--;
                    }
                    else  //6% chance 2 enemies die
                    {
                        playerStats.EnemiesRemaining -= 2;
                    }
                }
            }

            if (playerStats.EnemiesRemaining > 4 && playerStats.EnemiesRemaining <= 10) //Executes when there are more than 4 enemies and less than 10 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 2) //2% chance an enemy will die
                {
                    playerStats.EnemiesRemaining--;
                }
            }

        }
    }
}