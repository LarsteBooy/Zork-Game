using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Locations
{
    public class Cabin : Location
    {
        public override string LocationName => "Cabin";

        public override bool IsPassable => true;
        public override bool IsLootable => true;
        public override bool HasLoot{ get;set; }

        private const string locationDescriptionDefault = "You see a cabin filled with epic lewt.";

        public Cabin(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
            int random = Rng.Next(0, 10);

            //70% chance the it contains loot
            if(random < 7)
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