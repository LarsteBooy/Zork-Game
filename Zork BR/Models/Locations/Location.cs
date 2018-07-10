using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Locations
{
    public abstract class Location
    {
        [Key]
        public int Id { get; set; }

        public abstract string LocationName { get; }
        public virtual string LocationDescription {
            get {return "Nothing to see here";}
            set { }
        }
    }
}