using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models.Commands
{
    public class SearchCommand : Command
    {
        private readonly string input;
        private readonly Story story = null;
        private readonly Player player = null;
        
        public SearchCommand(string input, Story story, Player player)
        {
            this.input = input;
            this.story = story;
            this.player = player;
        }

        public override string MyAction()
        {
            string appendToStory = "";

            if (player.PlayerLocation is Cabin) {

                //Code om inventory van cabin te doorzoeken

                //if Items are found
                appendToStory += "I found ..." + MyStaticVars.WhiteLine(); ;
                //else
                appendToStory += "I found nothing" + MyStaticVars.WhiteLine();
                

                return appendToStory;
            }
            else if(player.PlayerLocation is Beach)
            {
                //Code om inventory van beach te doorzoeken

                //if Items are found
                appendToStory += "I found ..." + MyStaticVars.WhiteLine();
                //else
                appendToStory += "I found nothing" + MyStaticVars.WhiteLine();

                return appendToStory;
            }
            else
            {
                return "I can't search here" + MyStaticVars.WhiteLine();
            }
        }
    }
}