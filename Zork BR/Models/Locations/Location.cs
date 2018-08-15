using System.ComponentModel.DataAnnotations;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Locations
{
    public abstract class Location
    {
        [Key]
        public int Id { get; set; }

        public abstract string LocationName { get; }
        public abstract bool IsPassable { get; }
        public bool IsLootable { get { return this is ILootList; } }
        public virtual bool HasLoot{ get; set; }

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