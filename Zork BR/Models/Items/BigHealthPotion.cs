namespace Zork_BR.Models.Items
{
    public class BigHealthPotion : Consumable
    {
        public override string Name { get => "Big Health Potion"; }

        public override int MaximumStackableQuantity => 3;

        public override int HealthRegain { get => 70;}
    }
}