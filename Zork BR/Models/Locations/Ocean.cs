using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Ocean : Location
    {

        //Location name
        public override string LocationName
        {
            get
            {
                return "Ocean";
            }
        }

        //Location Description
        public override string LocationDescription
        {
            get; set;
        }

        //Constructors
        public Ocean(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Ocean()
        {
        }

    }
}