using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Cabin : Location
    {
        public override string LocationName
        {
            get
            {
                return "Cabin";
            }
        }

        public override string LocationDescription
        {
            get; set;
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