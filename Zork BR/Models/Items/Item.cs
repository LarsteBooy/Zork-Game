using System.ComponentModel.DataAnnotations;

namespace Zork_BR.Models
{
    public abstract class Item
    {
        [Key]
        public int Id { get; set; }

        public abstract string Name { get; }
        
    }
}