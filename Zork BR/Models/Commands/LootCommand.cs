using System.Diagnostics;
using Zork_BR.Models.Items;
using Zork_BR.Models.Locations;
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
        


        public override string MyAction()
        {
            string appendToStory = "";

            if (player.CurrentLocation.IsLootable == true) {
                if(player.CurrentLocation.HasLoot == true)
                {
                    //Code om inventory van location te doorzoeken
                    if (player.CurrentLocation is ILootList location)
                    {
                        if(location is Cabin)
                        {
                            LootTables.HealthTable(location);
                        }

                        if (location is Beach)
                        {
                            LootTables.HealthTable(location);
                        }


                        foreach (Item i in location.LootList)
                        {
                            appendToStory += Player.inventoryPlayer.AddItem(i);
                        }

                        if (location.LootList.Count == 0)
                        {
                            appendToStory += "everything you saw was useless" + MyStaticClass.WhiteLine(); ;
                        }
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