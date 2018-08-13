namespace Zork_BR.Models
{
    public abstract class Item
    {
        public int Id { get; set; }

        public abstract string Name { get; set; }
        
    }
}