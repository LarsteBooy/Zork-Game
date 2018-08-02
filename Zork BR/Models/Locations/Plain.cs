using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Plain : Location
    {
        public override string LocationName => "Plain";

        public override bool IsPassable => true;
        public override bool IsLootable => false;

        private const string locationDescriptionDefault = "You are at a plain which looks very empty, but you see vleespoeder on the ground.";

        public Plain(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
       
    }
}