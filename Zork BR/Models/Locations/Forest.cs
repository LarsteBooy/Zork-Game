using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Forest : Location
    {
        public override string LocationName => "Forest";

        public override bool IsPassable => true;

        public Forest(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Forest()
        {
        }
    }
}