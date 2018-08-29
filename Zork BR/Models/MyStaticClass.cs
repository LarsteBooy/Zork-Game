using System;

namespace Zork_BR.Models
{
    public static class MyStaticClass
    {
        //if true renders more minimap
        public static bool RenderMinimap { get; set; }

        //How much inventoryslots does the player have
        public static int MaximumItemsInInventory { get; set; } = 5;

        //How many enemies are remaining
        public static int EnemiesRemaining { get; set; } = 99;

        public static string WhiteLine()
        {
            return Environment.NewLine + Environment.NewLine;
        }

        

    }
}