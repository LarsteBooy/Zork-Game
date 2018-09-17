using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zork_BR.Models.Items;

namespace Zork_BR.Models
{
    public abstract class Item
    {
        [Key]
        public int Id { get; set; }

        public abstract string Name { get;}
    }
}