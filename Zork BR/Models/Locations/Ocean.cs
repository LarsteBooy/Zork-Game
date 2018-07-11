using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Ocean : Location
    {
        public override string LocationName
        {
            get
            {
                return "Ocean";
            }
        }

        public override bool IsPassable => false;

        public override string LocationDescription
        {
            get {
                return "The ocean is very dangerous, it would not be wise to go here. Also you cant swim\n\n";
            }
            set {
                LocationDescription = value;
            }
        }

        public Ocean(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Ocean()
        {
        }
    }
}