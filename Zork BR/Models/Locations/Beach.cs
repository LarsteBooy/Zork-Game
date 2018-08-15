using System.Collections.Generic;
using Zork_BR.Models.Items;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Locations
{
    public class Beach : Location, ILootList
    {
        public override string LocationName => "Beach";

        public override bool IsPassable => true;
        public override bool HasLoot{ get; set; }
        public ICollection<Item> LootList { get; set; }
        private const string locationDescriptionDefault = "Son of a beach, there is sand in places you don't want to talk about";

        public Beach(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
            LootList = new List<Item>();

            //90% chance it contains loot
            int random = Rng.Next(0, 10);
            HasLoot = random < 9;
        }

        public void CreateLootTables()
        {
            LootTables.HealthTable(this);

        }
    }
}