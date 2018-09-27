using System;
using System.Collections.Generic;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands
{
    public class LootCommand : Command
    {
        private readonly string input;
        private readonly Player player = null;
        private readonly PlayerStats playerStats = null;

        public LootCommand(string input, Player player, PlayerStats playerStats)
        {
            this.input = input;
            this.player = player;
            this.playerStats = playerStats;
        }

        public override string MyAction()
        {
            string appendToStory = "";
            
            if (!player.CurrentLocation.IsLootable)
            {
                return "You can't loot here" + MyStaticClass.WhiteLine();
            }

            if (!player.CurrentLocation.HasLoot)
            {
                return "This place was already looted" + MyStaticClass.WhiteLine();
            }

            ILootList location = player.CurrentLocation as ILootList;
            location.CreateLootTables();

            if (location.LootList.Count == 0)
            {
                return "You searched the entire place, but everything you found was useless" + MyStaticClass.WhiteLine();
            }

            var pickedUp = new List<Item>();
            foreach (Item i in location.LootList)
            {
                if (player.PlayerInventorySystem.NumberOfItems < playerStats.MaximumItemsInInventory)
                {
                    player.PlayerInventorySystem.AddItem(i);
                    pickedUp.Add(i);

                    appendToStory += String.Format("You found a {0}" + MyStaticClass.WhiteLine(), i.Name);
                }
            }

            RemoveFromLootList(location.LootList, pickedUp);
            
            if (location.LootList.Count > 0)
            {
                appendToStory += "Your inventory is full" + MyStaticClass.WhiteLine();
            }
            if (location.LootList.Count == 0)
            {
                player.CurrentLocation.HasLoot = false;
            }

            return appendToStory;
        }

        private void RemoveFromLootList(ICollection<Item> lootlist, List<Item> pickedUp)
        {
            foreach (var item in pickedUp)
            {
                lootlist.Remove(item);
            }
        }
    }
}