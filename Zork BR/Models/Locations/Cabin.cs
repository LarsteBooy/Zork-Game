using System.Collections.Generic;
using Zork_BR.Models.Items;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Locations
{
    public class Cabin : Location, ILootList
    {
        public override string LocationName => "Cabin";

        public override bool IsPassable => true;
        public override bool IsLootable => true;
        public override bool HasLoot{ get; set; }
        public ICollection<Item> LootList { get ; set ; }
        private const string locationDescriptionDefault = "You see a cabin filled with epic lewt.";

        public Cabin(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
            LootList = new List<Item>();

            //70% chance it contains loot
            int random = Rng.Next(0, 10);
            HasLoot = random < 7;
        }
    }
}