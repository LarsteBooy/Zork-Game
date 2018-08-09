namespace Zork_BR.Models.Items
{
    public class NormalHealthPotion : Consumable
    {
        public override string Name => "Health Potion";

        public override int MaximumStackableQuantity => 5;

        public override int HealthRegain => 50;
    }
}