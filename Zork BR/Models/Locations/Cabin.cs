using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Cabin : Location
    {
        //Location Name
        public override string LocationName
        {
            get
            {
                return "Cabin";
            }
        }

        //Location Description
        public override string LocationDescription
        {
            get; set;
        }

        //Constructors
        public Cabin(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Cabin()
        {
        }
    }
}