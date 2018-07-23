using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models;

namespace Zork_BR.Controllers
{
    public class StoryRepository 
    {


        public string SpawnStory()
        {
            string spawnStory = "";

            //TODO voeg hier een begin story toe. eventueel met hoe het spel werkt.
            spawnStory += String.Format("You get dropped at the coordinates [{0},{1}] which is a {2}\n", player.YCoord, player.XCoord, Map.map[player.YCoord, player.XCoord].LocationName);
            spawnStory += "You take a good look arround to get your surroundings\n\n";

            spawnStory += NearbyLocations();

            return spawnStory;
        }


    }
}