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

        string appendToStory = "No enemies in sight" + MyStaticClass.WhiteLine();

        private void ChanceToSpawnEnemy(Enemy enemy, int chanceToSpawn)
        {
            int random = Rng.Next(0, 100);

            if(random < chanceToSpawn)
            {
                player.CurrentLocation.Enemy = enemy;
                player.InBattle = true;
                appendToStory = string.Format("You see a {0} and ask for help. Than you remember you are in a game and these are your enemies so you engage in combat. {1}", player.CurrentLocation.Enemy.Name, MyStaticClass.WhiteLine());
            }
        }

        public string SpawnEnemy()
        {
            Location location = player.CurrentLocation;

            if(MyStaticClass.EnemiesRemaining > 70) //If there are more than 70 enemies remaining
            {
                ChanceToSpawnEnemy(new Regular(), 60);
            }

            if (MyStaticClass.EnemiesRemaining > 40 && MyStaticClass.EnemiesRemaining <= 70) //if there are more than 40 enemies and less than 70
            {
                ChanceToSpawnEnemy(new Brute(), 40);
                ChanceToSpawnEnemy(new Regular(), 40);
                
            }

            if (MyStaticClass.EnemiesRemaining > 10 && MyStaticClass.EnemiesRemaining <= 40) //if there are more than 10 enemies and less than 40
            {
                ChanceToSpawnEnemy(new Regular(), 20);
            }

            if (MyStaticClass.EnemiesRemaining > 0 && MyStaticClass.EnemiesRemaining <= 10) //if there are more than 10 enemies and less than 40
            {
                ChanceToSpawnEnemy(new Regular(), 5);
            }

            return appendToStory;
        }

        public void RandomEnemyDeath()
        {

            if(MyStaticClass.EnemiesRemaining > 80) //Executes when there are more than 80 enemies remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if(chanceToDie < 65) //65% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if(howManyDeath < 50) //50% 1 enemy dies
                    {
                        MyStaticClass.EnemiesRemaining--;
                    }
                    else if(howManyDeath >= 50 && howManyDeath < 86) //35% chance 2 enemies die
                    {
                        MyStaticClass.EnemiesRemaining -= 2;
                    }
                    else //15% chance 3 enemies die
                    {
                        MyStaticClass.EnemiesRemaining -= 3;
                    }
                }
            }

            if(MyStaticClass.EnemiesRemaining > 60 && MyStaticClass.EnemiesRemaining <= 80) //Executes when there are more than 60 enemies and less than 80 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 35) //35% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if (howManyDeath < 65) //65% 1 enemy dies
                    {
                        MyStaticClass.EnemiesRemaining--;
                    }
                    else if (howManyDeath >= 65 && howManyDeath < 96) //30% chance 2 enemies die
                    {
                        MyStaticClass.EnemiesRemaining -= 2;
                    }
                    else //5% chance 3 enemies die
                    {
                        MyStaticClass.EnemiesRemaining -= 3;
                    }
                }
            }

            if (MyStaticClass.EnemiesRemaining > 40 && MyStaticClass.EnemiesRemaining <= 60) //Executes when there are more than 40 enemies and less than 60 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 20) //20% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if (howManyDeath < 80) //80% 1 enemy dies
                    {
                        MyStaticClass.EnemiesRemaining--;
                    }
                    else if (howManyDeath >= 80 && howManyDeath < 100) //19% chance 2 enemies die
                    {
                        MyStaticClass.EnemiesRemaining -= 2;
                    }
                    else //1% chance 3 enemies die
                    {
                        MyStaticClass.EnemiesRemaining -= 3;
                    }
                }
            }

            if (MyStaticClass.EnemiesRemaining > 10 && MyStaticClass.EnemiesRemaining <= 40) //Executes when there are more than 10 enemies and less than 40 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 10) //10% chance enemies will die
                {
                    int howManyDeath = Rng.Next(0, 100);
                    if (howManyDeath < 94) //94% 1 enemy dies
                    {
                        MyStaticClass.EnemiesRemaining--;
                    }
                    else  //6% chance 2 enemies die
                    {
                        MyStaticClass.EnemiesRemaining -= 2;
                    }
                }
            }

            if (MyStaticClass.EnemiesRemaining > 4 && MyStaticClass.EnemiesRemaining <= 10) //Executes when there are more than 4 enemies and less than 10 remaining
            {
                int chanceToDie = Rng.Next(0, 100);
                if (chanceToDie < 2) //2% chance an enemy will die
                {
                    MyStaticClass.EnemiesRemaining--;
                }
            }

        }
    }
}