using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

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

                context.Stories.Attach(story);

                string dontGoInOcean = "The ocean is very dangerous, it would not be wise to go here. Also you cant swim\n\n";
                string currentLocation = String.Format("You are now at [{0},{1}]\n\n", player.YCoord, player.XCoord);

                if (input == "north")
                {
                    if(Map.map[player.YCoord -1, player.XCoord].GetType().Name == "Ocean")
                    {
                        story.MyStory += dontGoInOcean;
                    }
                    else
                    {
                        player.YCoord--;
                        story.MyStory += currentLocation;
                    }
                }
                else if(input == "east")
                {
                    if(Map.map[player.YCoord, player.XCoord + 1].GetType().Name == "Ocean")
                    {
                        story.MyStory += dontGoInOcean;
                    }
                    else
                    {
                        player.XCoord++;
                        story.MyStory += currentLocation;
                    }
                }
                else if(input == "south")
                {
                    if(Map.map[player.YCoord + 1, player.XCoord].GetType().Name == "Ocean")
                    {
                        story.MyStory += dontGoInOcean;
                    }
                    else
                    {
                        player.YCoord++;
                        story.MyStory += currentLocation;
                    }
                }
                else if(input == "west")
                {
                    if(Map.map[player.YCoord, player.XCoord - 1].GetType().Name == "Ocean")
                    {
                        story.MyStory += dontGoInOcean;
                    }
                    else
                    { 
                        player.XCoord--;
                        story.MyStory += currentLocation;
                    }
                }

                context.SaveChanges();

            }

        }


    }
}