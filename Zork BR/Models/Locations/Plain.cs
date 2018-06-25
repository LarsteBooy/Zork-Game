using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Plain : Location
    {
        //Location name
        public override string LocationName
        {
            get
            {
                return "Field";
            }
        }

        //Location Description
        public override string LocationDescription
        {
            get; set;
        }

        //Constructors
        public Plain(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Plain()
        {
        }
    }
}