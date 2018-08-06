using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork_BR.Models.Items
{
    public class InventorySystem
    {
        public readonly List<InventorySlot> inventorySlots = new List<InventorySlot>();

        public void AddItem(Item item, int quantityToAdd)
        {
            while(quantityToAdd > 0)
            {
                // If an object of this item type already exists in the inventory, and has room to stack more items,
                // then add as many as we can to that stack.
                if (inventorySlots.Exists(x => (x.InventoryItem.Id == item.Id) && (x.Quantity < item.MaximumStackableQuantity)))
                {
                    // Get the item we're going to add quantity to
                    InventorySlot inventorySlot = inventorySlots.First(x => (x.InventoryItem.Id == item.Id) && (x.Quantity < item.MaximumStackableQuantity));

                    // Calculate how many more can be added to this stack
                    int maximumQuantityYouCanAddToThisStack = (item.MaximumStackableQuantity - inventorySlot.Quantity);

                    // Add to the stack (either the full quantity, or the amount that would make it reach the stack maximum)
                    int quantityToAddToStack = Math.Min(quantityToAdd, maximumQuantityYouCanAddToThisStack);

                    inventorySlot.AddToQuantity(quantityToAddToStack);

                    // Decrease the quantityToAdd by the amount we added to the stack.
                    // If we added the total quantityToAdd to the stack, then this value will be 0, and we'll exit the 'while' loop.
                    quantityToAdd -= quantityToAddToStack;
                }
                else
                {
                    // We don't already have an existing inventorySlot for this Item object,
                    // so, add one to the list, if there is room.
                    if (inventorySlots.Count < MyStaticClass.MaximumSlotsInInventory)
                    {
                        // Don't set the quantity value here.
                        // The 'while' loop will take us back to the code above, which will add to the quantity.
                        inventorySlots.Add(new InventorySlot(item, 0));
                    }
                    else
                    {
                        // Let the user know he's out of inventory space (return a string) 
                        //TODO moet nog aangepast worden
                        throw new Exception("There is no more space in the inventory");
                    }
                }
            }
        }
    }
}