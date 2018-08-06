using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Locations
{
    public class Beach : Location
    {
        public override string LocationName => "Beach";

        public override bool IsPassable => true;
        public override bool IsLootable => true;
        
        public override bool HasLoot{ get; set; }

        private const string locationDescriptionDefault = "Son of a beach, there is sand in places you don't want to talk about";

        public Beach(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
            int random = Rng.Next(0, 10);

            //10% chance the it contains loot
            if (random < 1)
            {
                HasLoot = true;
            }
            else
            {
                HasLoot = false;
            }
        }
    }
}