namespace Zork_BR.Models
{
    public abstract class Item
    {
        public abstract string Name { get; set; }

        public virtual int Amount { get; set; }
    }
}