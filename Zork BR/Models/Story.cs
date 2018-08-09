using System.ComponentModel.DataAnnotations;

namespace Zork_BR.Models
{
    public class Story
    {
        [Key]
        public int Id { get; set; }
        public string MyStory { get; set; }
    }
}