using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models;

namespace Zork_BR.ViewModels
{
    public class HelpViewModel
    {
        public string GetMap{
            get {
                string updatedMap = "";

                for (int y = 0; y < 32; y++)
                {
                    updatedMap += "<tr>";
                    for(int x = 0; x < 32; x++)
                    {
                        updatedMap += string.Format("<td id='fullMapCel'><img src = '/Content/images/{0}.png' /></td>", Map.map[y,x].ImageName);
                    }
                    updatedMap += "</tr>";
                }
                return updatedMap;
            }
            set { }
        }

    }
}