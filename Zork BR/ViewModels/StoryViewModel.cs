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
        //public int XCoord { get; set; }
        //public int YCoord { get; set; }
        public string Location { get; set; }
        public string ImageEast { get; set; }
        public string LocationWest { get; set; }

        public StoryViewModel(Story story, Player player)
        {
            Id = story.Id;
            StoryText = story.MyStory;
            this.ImageEast = string.Format("<img src = '/Content/images/{0}.png' />", );
            //XCoord = player.XCoord;
            //YCoord = player.YCoord;
        }
    }
}