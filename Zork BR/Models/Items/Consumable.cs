namespace Zork_BR.Models.Items
{
    public abstract class Consumable : Item
    {
        public virtual int HealthRegain { get; set; }
    }
}