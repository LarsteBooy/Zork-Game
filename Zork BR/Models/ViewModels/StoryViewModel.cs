using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models;

namespace Zork_BR.ViewModels
{
    public class StoryViewModel
    {
        public int Id { get; set; }
        public string StoryText { get; set; }

        public string ImageCurrent{ get; set; }
        public string ImageNorth { get; set; }
        public string ImageEast { get; set; }
        public string ImageSouth { get; set; }
        public string ImageWest { get; set; }
        public string ImageNorthWest { get; set; }
        public string ImageNorthEast { get; set; }
        public string ImageSouthEast { get; set; }
        public string ImageSouthWest { get; set; }
        public string ImageNorthNorth { get; set; }
        public string ImageEastEast { get; set; }
        public string ImageSouthSouth { get; set; }
        public string ImageWestWest { get; set; }
        public string ImageFogOfWar {
            get {
                return string.Format("<img src = '/Content/images/fogofwar.png' />");
            }
            set { }
        }
        /* Dit en de tabel uit de index.html uitcommenten om de volledige map op te vragen 
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
        */


        public StoryViewModel(Story story, Player player)
        {
            this.Id = story.Id;
            this.StoryText = story.MyStory;
            if (player != null && story != null)
            {
                this.ImageCurrent = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord, player.XCoord].ImageName);
                this.ImageNorth = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 1, player.XCoord].ImageName);
                this.ImageEast = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord, player.XCoord + 1].ImageName);
                this.ImageSouth = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 1, player.XCoord].ImageName);
                this.ImageWest = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord, player.XCoord - 1].ImageName);
                this.ImageNorthWest = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 1, player.XCoord - 1].ImageName);
                this.ImageNorthEast = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 1, player.XCoord + 1].ImageName);
                this.ImageSouthEast = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 1, player.XCoord + 1].ImageName);
                this.ImageSouthWest = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 1, player.XCoord - 1].ImageName);
                this.ImageNorthNorth = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 2, player.XCoord].ImageName);
                this.ImageEastEast = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord, player.XCoord + 2].ImageName);
                this.ImageSouthSouth = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 2, player.XCoord].ImageName);
                this.ImageWestWest = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord, player.XCoord - 2].ImageName);
            }
        }
    }
}