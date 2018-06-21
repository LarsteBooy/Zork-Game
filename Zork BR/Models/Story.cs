using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zork_BR.Models
{
    public class Story
    {
        [Key]
        public int Id { get; set; }
        public string MyStory { get; set; }
    }
}