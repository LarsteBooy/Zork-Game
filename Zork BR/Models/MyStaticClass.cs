using System;

namespace Zork_BR.Models
{
    public static class MyStaticClass
    {
        public static bool RenderMinimap { get; set; }

        public static int MaximumItemsInInventory { get; set; } = 1; 

        public static string WhiteLine()
        {
            return Environment.NewLine + Environment.NewLine;
        }

    }
}