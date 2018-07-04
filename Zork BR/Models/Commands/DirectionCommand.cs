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
                var player = context.Players.Find(id);

                if (input == "north")
                {
                    player.YCoord--;
                    Debug.WriteLine("You are now at [{0},{1}]", player.YCoord, player.XCoord);
                }
                else if(input == "east")
                {
                    player.XCoord++;
                    Debug.WriteLine("You are now at [{0},{1}]", player.YCoord, player.XCoord);
                }
                else if(input == "south")
                {
                    player.YCoord++;
                    Debug.WriteLine("You are now at [{0},{1}]", player.YCoord, player.XCoord);
                }
                else if(input == "west")
                {
                    player.XCoord--;
                    Debug.WriteLine("You are now at [{0},{1}]", player.YCoord, player.XCoord);
                }

                context.SaveChanges();

            }

        }


    }
}