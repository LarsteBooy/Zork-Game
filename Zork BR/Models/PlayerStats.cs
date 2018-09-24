using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zork_BR.Models.Items;

namespace Zork_BR.Models
{
    public class PlayerStats
    {
        [Key, ForeignKey("PlayerInventory")]
        public int Id { get; set; }

        public PlayerInventorySystem PlayerInventory { get; set; }

        //How many enemies are remaining
        public int EnemiesRemaining { get; set; } = 99;

        //How much inventoryslots does the player have
        public int MaximumItemsInInventory { get; set; } = 8;

        //if true renders more minimap
        public bool RenderMinimap { get; set; }

        //How many kills does the player have
        public int Kills { get; set; }
    }
}