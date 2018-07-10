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

        public override string LocationDescription
        {
            get; set;
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