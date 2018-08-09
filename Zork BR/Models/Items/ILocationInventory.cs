using System.Collections.Generic;

namespace Zork_BR.Models.Items
{
    interface ILootList
    {
        ICollection<Item> LootList { get; set; }
    }
}
