using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models.Commands
{
    public class DirectionCommand : Command
    {
        private readonly string input;
        private readonly int id = 0;
        private readonly Story story = null;
        private readonly Player player = null;



        public DirectionCommand(string input, int id, Story story, Player player)
        {
            this.input = input;
            this.id = id;
            this.story = story;
            this.player = player;
        }

        public override string MyAction()
        {
                string CurrentLocation()
                {
                    string currentLocation = String.Format("You are now at [{0},{1}]" + Environment.NewLine + Environment.NewLine, player.YCoord, player.XCoord );

                    return currentLocation;
                }
             
                if (input == "north")
                {
                    Location locationNorth = Map.map[player.YCoord - 1, player.XCoord];
                    if (locationNorth.IsPassable == false) 
                    {
                        return locationNorth.LocationDescription + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        player.YCoord--;
                        return CurrentLocation();
                    }
                }
                else if(input == "east")
                {
                    Location locationEast = Map.map[player.YCoord, player.XCoord + 1];
                    if (locationEast.IsPassable == false)
                    {
                        return locationEast.LocationDescription + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        player.XCoord++;
                        return CurrentLocation();
                    }
                }
                else if(input == "south")
                {
                    Location locationSouth = Map.map[player.YCoord + 1, player.XCoord];
                    if (locationSouth.IsPassable == false)
                    {
                        return locationSouth.LocationDescription + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        player.YCoord++;
                        return CurrentLocation();
                    }
                }
                else if(input == "west")
                {
                    Location locationWest = Map.map[player.YCoord, player.XCoord - 1];
                    if (locationWest.IsPassable == false)
                    {
                        return locationWest.LocationDescription + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    { 
                        player.XCoord--;
                        return CurrentLocation();
                    }
                }
            else
            {
                return "This is not a direction you can go to";
            }
        }
    }
}