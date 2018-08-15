using System.Collections.Generic;

namespace Zork_BR.Models.Items
{
    public interface ILootList
    {
        ICollection<Item> LootList { get; set; }
        void CreateLootTables();
    }
}
