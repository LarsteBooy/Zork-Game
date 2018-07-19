using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Beach : Location
    {
        public override string LocationName => "Beach";

        public override bool IsPassable => true;

        private const string locationDescriptionDefault = "Son of a beach, there is sand in places you don't want to talk about";

        public Beach(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
    }
}