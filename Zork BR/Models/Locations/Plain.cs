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

        public override string LocationDescription
        {
            get; set;
        }

        public Plain(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Plain()
        {
        }
    }
}