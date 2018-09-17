namespace Zork_BR.Models.Items.Consumables
{
    public class NormalHealthPotion : HealthPotion, IHealthRegain
    {
        public override string Name => "Normal Healthpotion";

        public override int HealthRegain { get => 50; }
    }
}