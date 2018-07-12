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

        public DirectionCommand(string input, int id)
        {
            this.input = input;
            this.id = id;
        }

        public override void MyAction()
        {
            using (var context = ApplicationDbContext.Create())
            { 
                Story story = context.Stories.Find(id);
                Player player = context.Players.Find(id);

                string CurrentLocation()
                {
                    string currentLocation = String.Format("You are now at [{0},{1}]\n\n", player.YCoord, player.XCoord);

                    return currentLocation;
                }
             
                if (input == "north")
                {
                    Location locationNorth = Map.map[player.YCoord - 1, player.XCoord];
                    if (locationNorth.IsPassable == false) 
                    {
                        story.MyStory += locationNorth.LocationDescription + "\n\n";
                    }
                    else
                    {
                        player.YCoord--;
                        story.MyStory += CurrentLocation();
                    }
                }
                else if(input == "east")
                {
                    Location locationEast = Map.map[player.YCoord, player.XCoord + 1];
                    if (locationEast.IsPassable == false)
                    {
                        story.MyStory += locationEast.LocationDescription + "\n\n";
                    }
                    else
                    {
                        player.XCoord++;
                        story.MyStory += CurrentLocation();
                    }
                }
                else if(input == "south")
                {
                    Location locationSouth = Map.map[player.YCoord + 1, player.XCoord];
                    if (locationSouth.IsPassable == false)
                    {
                        story.MyStory += locationSouth.LocationDescription + "\n\n";
                    }
                    else
                    {
                        player.YCoord++;
                        story.MyStory += CurrentLocation();
                    }
                }
                else if(input == "west")
                {
                    Location locationWest = Map.map[player.YCoord, player.XCoord - 1];
                    if (locationWest.IsPassable == false)
                    {
                        story.MyStory += locationWest.LocationDescription + "\n\n";
                    }
                    else
                    { 
                        player.XCoord--;
                        story.MyStory += CurrentLocation();
                    }
                }
                context.SaveChanges();
            }
        }
    }
}