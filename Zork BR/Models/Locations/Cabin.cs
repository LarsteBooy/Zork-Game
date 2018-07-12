using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Cabin : Location
    {
        public override string LocationName => "Cabin";

        public override bool IsPassable => true;

        private const string locationDescriptionDefault = "You see a cabin filled with epic lewt.";

        public Cabin(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
    }
}