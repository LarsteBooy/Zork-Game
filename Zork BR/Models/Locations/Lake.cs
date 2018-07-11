using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Lake : Location
    {
        public override string LocationName => "Lake";

        public override bool IsPassable => false;


        public Lake(string locationDescription)
        {
            LocationDescription = locationDescription;
        }

        public Lake()
        {
        }
    }
}