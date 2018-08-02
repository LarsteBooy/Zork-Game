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
        public override bool HasLoot
        {
            get
            {
                //TODO Random does not work hier, everytime the page refreshes there is a new 70% chance the cabin got loot
                int random = Rng.Next(0, 10);
                //70% chance the cabin has loot
                if(random >= 0 && random < 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set => base.HasLoot = value;
        }

        private const string locationDescriptionDefault = "You see a cabin filled with epic lewt.";

        public Cabin(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
    }
}