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