namespace Zork_BR.Models.Items
{
    public class BigHealthPotion : Consumable
    {
        public override string Name { get => "BigHealthPotion"; }

        public override int MaximumStackableQuantity => 3;

        public override int HealthRegain { get => 70;}
    }
}