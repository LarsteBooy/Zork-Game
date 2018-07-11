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

        public override string LocationDescription
        {
            get {
                return "";

            }
            set {
                LocationDescription = value;
            }
        }

        public Cabin(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Cabin()
        {
        }
    }
}