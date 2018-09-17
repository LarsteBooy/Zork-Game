using Zork_BR.Models.Items;
using Zork_BR.Models.Items.Consumables;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models
{
    public static class LootTables
    {
        
        public static void HealthTable(ILootList location)
        {
            int chanceForHealthTable = Rng.Next(0, 100); 
            if (chanceForHealthTable < 75) //75% chance for a item from HealthTable
            {
                int whichPotion = Rng.Next(0, 100);
                if (whichPotion < 60)    //60% chance for SmallHealthPotion
                {
                    location.LootList.Add(new SmallHealthPotion());
                }
                else if (whichPotion >= 60 && whichPotion < 90) //30% chance for NormalHealthPotion
                {
                    location.LootList.Add(new NormalHealthPotion());
                }
                else //10% chance for BigHealthPotion
                {
                    location.LootList.Add(new BigHealthPotion()); 
                }
            }
        }

        public static void RareItemTable(ILootList location)
        {
            int chanceForRareItemTable = Rng.Next(0, 100);
            if(chanceForRareItemTable < 90) //10% chance for a item from RareItemTable
            {
                int chanceForBinoculars = Rng.Next(0, 100);
                if(chanceForBinoculars < 50) //50% chance for a Binoculars
                {
                    location.LootList.Add(new Binoculars());
                }
                else //50% chance for a Backpack
                {
                    location.LootList.Add(new Backpack());
                }
            }

        }
    }
}