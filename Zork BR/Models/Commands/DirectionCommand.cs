using System;
using Zork_BR.Models.Locations;

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
                        return CurrentLocationDescription() + CurrentLocation();
                    case "east":
                    case "1":
                        player.XCoord++;
                        return CurrentLocationDescription() + CurrentLocation();
                    case "south":
                    case "2":
                        player.YCoord++;
                        return CurrentLocationDescription() + CurrentLocation();
                    case "west":
                    case "3":
                        player.XCoord--;
                        return CurrentLocationDescription() + CurrentLocation();
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
            
        }
    }
}