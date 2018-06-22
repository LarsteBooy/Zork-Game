using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }

        //public Location[,] map = new Location[32,32];
        //List<List<Location>> map = new List<List<Location>>();
        ArrayList<Location>[][] map = new System.Collections.ArrayList<Location>[32][32];

        public void Buildmap()
        {
            map.Add
        }
    }
}