using Zork_BR.Models.Items;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models
{
    public static class LootTables
    {
        
        public static void HealthTable(ILootList location)
        {
            int chanceForHealth = Rng.Next(0, 100); //75% chance for a healthpotion
            if (chanceForHealth < 75)
            {
                int whichPotion = Rng.Next(0, 100);
                if (whichPotion < 60)    //60% chance for SmallHealthPotion
                {
                    location.LootList.Add(new HealthPotion("Small Health Potion", 30));
                }
                else if (whichPotion >= 60 && whichPotion < 90) //30% chance for NormalHealthPotion
                {
                    location.LootList.Add(new HealthPotion("Normal Health Potion", 50));
                }
                else
                {
                    location.LootList.Add(new HealthPotion("Big Health Potion", 70)); //10% chance for BigHealthPotion
                }
            }
        }
    }
}