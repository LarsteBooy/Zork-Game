namespace Zork_BR.Models
{
    public abstract class Item
    {
        public int Id { get; set; }

        public abstract string Name { get;}

        public int maximumStackableQuantityDefault = 1;
        public virtual int MaximumStackableQuantity
        {
            get { return maximumStackableQuantityDefault; }
        }
        
    }
}