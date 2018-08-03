using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models;
using Zork_BR.Models.Commands;

namespace Zork_BR.ViewModels
{
    public class StoryViewModel
    {
        public int Id { get; set; }
        public string StoryText { get; set; }

        //if true render more locations on the minimap
        public bool Render {
            get
            {
                return Render = MyStaticVars.RenderMinimap;
            }
            set { }
        }

        //minimap images
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
        public string ImageNorth2West2 { get; set; }
        public string ImageNorth2West1 { get; set; }
        public string ImageNorth2East1 { get; set; }
        public string ImageNorth2East2 { get; set; }
        public string ImageNorth1West2 { get; set; }
        public string ImageNorth1East2 { get; set; }
        public string ImageSouth1West2 { get; set; }
        public string ImageSouth1East2 { get; set; }
        public string ImageSouth2West2 { get; set; }
        public string ImageSouth2West1 { get; set; }
        public string ImageSouth2East1 { get; set; }
        public string ImageSouth2East2 { get; set; }


        public string RenderMinimap(string location)
        {
            if (Render == true)
            {
                switch (location)
                {
                    case "north2west2": return ImageNorth2West2;
                    case "north2west1": return ImageNorth2West1;
                    case "north2east1": return ImageNorth2East1;
                    case "north2east2": return ImageNorth2East2;
                    case "north1west2": return ImageNorth1West2;
                    case "north1east2": return ImageNorth1East2;
                    case "south1west2": return ImageSouth1West2;
                    case "south1east2": return ImageSouth1East2;
                    case "south2west2": return ImageSouth2West2;
                    case "south2west1": return ImageSouth2West1;
                    case "south2east1": return ImageSouth2East1;
                    case "south2east2": return ImageSouth2East2;
                    default: return ImageFogOfWar;
                }
            }
            else
            {
                return ImageFogOfWar;
            }
        }

        public string ImageFogOfWar {
            get {
                return string.Format("<img src = '/Content/images/fogofwar.png' />");
            }
            set { }
        }
        




        public StoryViewModel(Story story, Player player)
        {
            this.Id = story.Id;
            this.StoryText = story.MyStory;
            if (player != null && story != null)
            {
                this.ImageCurrent = string.Format("<img src = '/Content/images/{0}.png' />", player.CurrentLocation.ImageName);
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
                this.ImageNorth2West2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 2, player.XCoord - 2].ImageName);
                this.ImageNorth2West1 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 2, player.XCoord - 1].ImageName);
                this.ImageNorth2East1 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 2, player.XCoord + 1].ImageName);
                this.ImageNorth2East2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 2, player.XCoord + 2].ImageName);
                this.ImageNorth1West2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 1, player.XCoord - 2].ImageName);
                this.ImageNorth1East2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord - 1, player.XCoord + 2].ImageName);
                this.ImageSouth1West2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 1, player.XCoord - 2].ImageName);
                this.ImageSouth1East2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 1, player.XCoord + 2].ImageName);
                this.ImageSouth2West2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 2, player.XCoord - 2].ImageName);
                this.ImageSouth2West1 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 2, player.XCoord - 1].ImageName);
                this.ImageSouth2East1 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 2, player.XCoord + 1].ImageName);
                this.ImageSouth2East2 = string.Format("<img src = '/Content/images/{0}.png' />", Map.map[player.YCoord + 2, player.XCoord + 2].ImageName);
            }
        }
    }
}