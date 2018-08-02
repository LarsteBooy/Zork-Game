using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Ocean : Location
    {
        public override string LocationName => "Ocean";

        public override bool IsPassable => false;
        public override bool IsLootable => false;

        private const string locationDescriptionDefault = "The ocean looks very dangerous, it would not be wise to go there. Also you can't swim";

        public Ocean(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
    }
}