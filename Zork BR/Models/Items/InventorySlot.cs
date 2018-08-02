namespace Zork_BR.Models.Items
{
    public class InventorySlot
    {
        public Item InventoryItem { get; private set; }
        public int Quantity { get; private set; }

        public InventorySlot(Item item, int amount)
        {
            InventoryItem = item;
            Quantity = amount;
        }

        public void AddToQuantity(int amountToAdd)
        {
            Quantity += amountToAdd;
        }
    }
}