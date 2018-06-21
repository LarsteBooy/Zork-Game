using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zork_BR.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }

        public object[,] map = new object[50,50];
    }
}