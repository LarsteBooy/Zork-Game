using System;
using System.Globalization;

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

        //Sets a string to Titlecase
        public static string ToTitleCase(this string input)
        {
            string updatedInput = input.Trim().ToLower();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(updatedInput);
        }
        

    }
}