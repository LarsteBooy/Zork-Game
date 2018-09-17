namespace Zork_BR.Models.Items.Consumables
{
    public abstract class HealthPotion : Item, IHealthRegain
    {
        public abstract int HealthRegain { get; }
    }
}