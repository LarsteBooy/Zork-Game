using System.Diagnostics;
using Zork_BR.Models.Items;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Commands
{
    public class LootCommand : Command
    {
        private readonly string input;
        private readonly Story story = null;
        private readonly Player player = null;
        
        public LootCommand(string input, Story story, Player player)
        {
            this.input = input;
            this.story = story;
            this.player = player;
        }
        
        //create lootlist
        private void CreateLootlist(ILootList location)
        {
            int chanceForHealth = Rng.Next(0, 100); //75% chance for a healthpotion
            if(chanceForHealth< 75)
            {
                int whichPotion = Rng.Next(0, 100);
                if(whichPotion< 60)    //60% chance for SmallHealthPotion
                {
                    location.LootList.Add(new SmallHealthPotion());
                }
                else if(whichPotion >= 60 && whichPotion< 90) //30% chance for NormalHealthPotion
                {
                    location.LootList.Add(new NormalHealthPotion());
                }
                else
                {
                    location.LootList.Add(new BigHealthPotion()); //10% chance for BigHealthPotion
                }
            }
        }

        public override string MyAction()
        {
            string appendToStory = "";

            if (player.CurrentLocation.IsLootable == true) {
                if(player.CurrentLocation.HasLoot == true)
                {
                    //Code om inventory van location te doorzoeken
                    if (player.CurrentLocation is ILootList location)
                    {
                        CreateLootlist(location);

                        foreach(Item i in location.LootList)
                        {
                            appendToStory += Player.inventoryPlayer.AddItem(i);
                        }

                        if (location.LootList.Count == 0)
                        {
                            appendToStory += "everything you saw was useless" + MyStaticClass.WhiteLine(); ;
                        }

                            Debug.WriteLine(string.Join(";", location.LootList));
                    }
                    player.CurrentLocation.HasLoot = false;
                }
                else
                {
                     appendToStory += "This place was already looted" + MyStaticClass.WhiteLine();
                }
                
                return appendToStory;
            }
            else
            {
                return "You can't loot here" + MyStaticClass.WhiteLine();
            }
        }
    }
}