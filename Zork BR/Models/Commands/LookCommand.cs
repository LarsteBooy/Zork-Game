using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models.Commands
{
    public class LookCommand : Command
    {

        readonly Player player = null;
        private readonly string input;

        public LookCommand(string input, Player player)
        {
            this.input = input;
            this.player = player;
        }

        public override string MyAction()
        {
            if (input.ToLowerInvariant() == "looknorth")
            {
                Location locationNorth = Map.map[player.YCoord - 1, player.XCoord];
                return string.Format("To your north you see a {0}{1}", locationNorth.LocationName, MyStaticClass.WhiteLine());
            }
            else if (input.ToLowerInvariant() == "lookeast")
            {
                Location locationEast = Map.map[player.YCoord, player.XCoord + 1];
                return string.Format("To your east you see a {0}{1}", locationEast.LocationName, MyStaticClass.WhiteLine());
            }
            else if (input.ToLowerInvariant() == "looksouth")
            {
                Location locationSouth = Map.map[player.YCoord + 1, player.XCoord];
                return string.Format("To your south you see a {0}{1}", locationSouth.LocationName, MyStaticClass.WhiteLine());
            }
            else if (input.ToLowerInvariant() == "lookwest")
            {
                Location locationWest = Map.map[player.YCoord, player.XCoord - 1];
                return string.Format("To your west you see a {0}{1}", locationWest.LocationName, MyStaticClass.WhiteLine());
            }
            else
            {
                return "This is not a direction you can look" + MyStaticClass.WhiteLine();
            }
        }
    }
}