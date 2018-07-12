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

        private const string locationDescriptionDefault = "The plain looks very empty, but you see vleespoeder on the ground.";

        public Plain(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
       
    }
}