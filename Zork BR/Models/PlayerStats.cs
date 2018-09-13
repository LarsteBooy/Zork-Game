using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zork_BR.Models
{
    public class PlayerStats
    {
        [Key]
        public int Id { get; set; }

        //How many enemies are remaining
        public int EnemiesRemaining { get; set; } = 2;

        //How much inventoryslots does the player have
        public int MaximumItemsInInventory { get; set; } = 8;

        //if true renders more minimap
        public bool RenderMinimap { get; set; }

        //How many kills does the player have
        public int Kills { get; set; }
    }
}