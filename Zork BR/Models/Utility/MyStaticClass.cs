using System;
using System.Globalization;

namespace Zork_BR.Models
{
    public static class MyStaticClass
    {        
        //Adds 2 new lines
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