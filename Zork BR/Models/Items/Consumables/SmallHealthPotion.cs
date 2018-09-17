namespace Zork_BR.Models.Items.Consumables
{
    public class SmallHealthPotion : HealthPotion, IHealthRegain
    {
        public override string Name => "Small Healthpotion";

        public override int HealthRegain { get => 30; }

    }
}