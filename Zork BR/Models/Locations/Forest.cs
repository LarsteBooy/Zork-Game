using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Forest : Location
    {

        //Location name
        public override string LocationName
        {
            get
            {
                return "Forest";
            }
        }

        //Location Description
        public override string LocationDescription
        {
            get; set;
        }

        //Constructors
        public Forest(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Forest()
        {
        }
    }
}