namespace Zork_BR.Models.Locations
{
    public class Lake : Location
    {
        public override string LocationName => "Lake";

        public override bool IsPassable => false;
        public override bool IsLootable => false;

        private const string locationDescriptionDefault = "You cant continue your journey in this direction, you really regret not taking swimming classes.";

        public Lake(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
        }
    }
}