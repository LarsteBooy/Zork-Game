namespace Zork_BR.Models.Locations
{
    public class Forest : Location
    {
        public override string LocationName => "Forest";

        public override bool IsPassable => true;
        public override bool IsLootable => false;

        private const string locationDescriptionDefault = "You see a ton of trees, you're probably in a forest.";

        public Forest(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
    }
}