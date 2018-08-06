using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Locations;

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

                    //if Items are found
                    appendToStory += "You found ..." + MyStaticClass.WhiteLine();

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