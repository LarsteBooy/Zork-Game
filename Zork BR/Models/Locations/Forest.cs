using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Forest : Location
    {
        public override string LocationName
        {
            get
            {
                return "Forest";
            }
        }
        
        public override string LocationDescription
        {
            get; set;
        }

        public Forest(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Forest()
        {
        }
    }
}