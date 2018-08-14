using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models;

namespace Zork_BR.ViewModels
{
    public class HelpViewModel
    {
        Player player;

        public HelpViewModel(Player player)
        {
            this.player = player;
        }

        public string GetMap{
            get {
                string updatedMap = "";

                for (int y = 0; y < 32; y++)
                {
                    updatedMap += "<tr>";
                    for(int x = 0; x < 32; x++)
                    {
                        updatedMap += string.Format("<td id='fullMapCel'><img src = '/Content/images/{0}.png' />", Map.map[y,x].ImageName);
                        if(Map.map[y,x] == player.CurrentLocation)
                        {
                            updatedMap += "<span id='fullMapPlayerLocation'>&#10006;</span>";
                        }
                        updatedMap += "</td>";
                    }
                    updatedMap += "</tr>";
                }
                return updatedMap;
            }
            set { }
        }

    }
}