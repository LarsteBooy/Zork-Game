using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_BR.Models.Items
{
    interface ILootList
    {
        ICollection<Item> LootList { get; set; }
    }
}
