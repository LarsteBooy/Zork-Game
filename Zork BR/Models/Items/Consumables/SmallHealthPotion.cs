﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Items.Consumables
{
    public class SmallHealthPotion : HealthPotion, IHealthRegain
    {
        public override string Name => "Small Healthpotion";

        public override int HealthRegain { get => 30; }

    }
}