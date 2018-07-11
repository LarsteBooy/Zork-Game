﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public class Ocean : Location
    {
        public override string LocationName => "Ocean";

        public override bool IsPassable => false;

        public override string LocationDescription
        {
            get => "The ocean looks very dangerous, it would not be wise to go there. Also you can't swim";
            set => base.LocationDescription = value;
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