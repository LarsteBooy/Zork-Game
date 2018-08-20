using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Zork_BR.Models.Enemies;
using Zork_BR.Models.Locations;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Commands
{
    public class DirectionCommand : Command
    {
        private readonly string input;
        private readonly Story story = null;
        private readonly Player player = null;
        
        public DirectionCommand(string input, Story story, Player player)
        {
            this.input = input;
            this.story = story;
            this.player = player;
        }

        public override string MyAction() //TODO Haal de input == cijfer weg en zorg ervoor dat de speler dit niet kan invoegen als input (de cijfer staat voor de plek van de command in de enum van CommandFactory). Hetzelfde geldt voor de navigate method
        {

            if (input == "north" || input == "0")
            {
                Location locationNorth = Map.map[player.YCoord - 1, player.XCoord];
                return Navigate(locationNorth, input);
            }
            else if (input == "east" || input == "1")
            {
                Location locationEast = Map.map[player.YCoord, player.XCoord + 1];
                return Navigate(locationEast, input);
            }
            else if (input == "south" || input == "2")
            {
                Location locationSouth = Map.map[player.YCoord + 1, player.XCoord];
                return Navigate(locationSouth, input);
            }
            else if (input == "west" || input == "3")
            {
                Location locationWest = Map.map[player.YCoord, player.XCoord - 1];
                return Navigate(locationWest, input);
            }
            else
            {
                return "This is not a direction you can go to" + Environment.NewLine;
            }



            string Navigate(Location location, string input)
            {
                if(!location.IsPassable)
                {
                    return location.LocationDescription + MyStaticClass.WhiteLine();
                }

                switch (input)
                {
                    case "north":
                    case "0":
                        player.YCoord--;
                        return CurrentLocationDescription() + CurrentLocation() + SpawnEnemy();
                    case "east":
                    case "1":
                        player.XCoord++;
                        return CurrentLocationDescription() + CurrentLocation() + SpawnEnemy();
                    case "south":
                    case "2":
                        player.YCoord++;
                        return CurrentLocationDescription() + CurrentLocation() + SpawnEnemy();
                    case "west":
                    case "3":
                        player.XCoord--;
                        return CurrentLocationDescription() + CurrentLocation() + SpawnEnemy();
                    default: return "Something broke" + Environment.NewLine;
                }
            }

            string CurrentLocation()
            {
                string currentLocation = String.Format("You are now at [{0},{1}]" + MyStaticClass.WhiteLine(), player.YCoord, player.XCoord);

                return currentLocation;
            }

            string CurrentLocationDescription()
            {
                return player.CurrentLocation.LocationDescription + MyStaticClass.WhiteLine();
            }

            string SpawnEnemy()
            {
                Location location = player.CurrentLocation;

                int chanceToSpawnEnemy = Rng.Next(0, 100);
                if(chanceToSpawnEnemy < 50)
                {
                    //TODO spawn hier enemy

                    using(var context = ApplicationDbContext.Create())
                    {
                        CommonEnemy commonEnemy = new CommonEnemy();
                        context.Enemies.Add(commonEnemy);

                        context.SaveChanges();
                    }

                    MyStaticClass.InBattle = true;
                    return "You see someone and ask for help. Than you remember you are in a game and these are your enemies so you engage in combat." + MyStaticClass.WhiteLine();
                }

                return "";
            }
        }
    }
}