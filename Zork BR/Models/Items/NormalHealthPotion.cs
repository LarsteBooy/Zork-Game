namespace Zork_BR.Models.Items
{
    public class NormalHealthPotion : Consumable
    {
        public override string Name => "Normal Health Potion";

        public override int MaximumStackableQuantity => 5;

        public override int HealthRegain => 50;
    }
}