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
        public abstract bool IsPassable { get; }
        public abstract bool IsLootable { get; }
        public virtual bool HasLoot
        {
            get;
            set;
        }

        public string LocationDescription {
            get;
            protected set;
        }

        public string ImageName
        {
            get
            {
                return GetType().Name.ToLower();
            }
        }
    }
}