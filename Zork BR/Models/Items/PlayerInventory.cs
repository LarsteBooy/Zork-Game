using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Zork_BR.Models.Items
{
    public class PlayerInventory
    {
        [Key, ForeignKey("Player")]
        public int Id { get; set; }
        
        public Player Player { get; set; }
        public PlayerStats PlayerStats { get; set; }

        public virtual ICollection<Item> Inventory { get; set; }
        public int NumberOfItems { get; set; }
        

        public PlayerInventory()
        {
            Inventory = new List<Item>();
        }
        

        public void AddItem(Item item)
        {
                if(item is Binoculars)
                {
                    PlayerStats.RenderMinimap = true;
                } 
                if(item is Backpack)
                {
                    PlayerStats.MaximumItemsInInventory = 13;
                }
                
                Inventory.Add(item);
                NumberOfItems++;
                
            }
            
        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);

            if (!Inventory.Any(x => x is Binoculars))
            {
                PlayerStats.RenderMinimap = false;
            }

            if (!Inventory.Any(x => x is Backpack))
            {
                PlayerStats.MaximumItemsInInventory = 8;
            }
            
            NumberOfItems--;
        }
    }
}