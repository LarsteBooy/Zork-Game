﻿using System;
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
        private readonly Story story = null;
        private readonly Player player = null;
        
        public DirectionCommand(string input, Story story, Player player)
        {
            this.input = input;
            this.story = story;
            this.player = player;
        }

        public override string MyAction()
        {

            if (input == "north")
            {
                Location locationNorth = Map.map[player.YCoord - 1, player.XCoord];
                return navigate(locationNorth, input);
            }
            else if (input == "east")
            {
                Location locationEast = Map.map[player.YCoord, player.XCoord + 1];
                return navigate(locationEast, input);
            }
            else if (input == "south")
            {
                Location locationSouth = Map.map[player.YCoord + 1, player.XCoord];
                return navigate(locationSouth, input);
            }
            else if (input == "west")
            {
                Location locationWest = Map.map[player.YCoord, player.XCoord - 1];
                return navigate(locationWest, input);
            }
            else
            {
                return "This is not a direction you can go to"; //unreachable
            }

            string CurrentLocation()
            {
                string currentLocation = String.Format("You are now at [{0},{1}]" + MyStaticClass.WhiteLine(), player.YCoord, player.XCoord );

                return currentLocation;
            }

            string navigate(Location location, string input)
            {
                if(location.IsPassable == false)
                {
                    return location.LocationDescription + MyStaticClass.WhiteLine();
                }
                else
                {
                    switch (input)
                    {
                        case "north": player.YCoord--;
                            return CurrentLocation();
                        case "east":
                            player.XCoord++;
                            return CurrentLocation();
                        case "south":
                            player.YCoord++;
                            return CurrentLocation();
                        case "west":
                            player.XCoord--;
                            return CurrentLocation();
                        default: return "Something broke";
                    }
                }
            }
        }
    }
}