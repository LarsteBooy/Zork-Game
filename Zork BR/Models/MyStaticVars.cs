﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models
{
    public static class MyStaticVars
    {
        public static bool RenderMinimap { get; set; }
        public static int MaximumSlotsInInventory { get; set; }

        public static string WhiteLine()
        {
            return Environment.NewLine + Environment.NewLine;
        }

    }
}