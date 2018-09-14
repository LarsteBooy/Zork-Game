using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands
{
    public class HealCommand : Command
    {
        Player player = null;

        public HealCommand(Player player)
        {
            this.player = player;
        }

        public override string MyAction()
        {
            List<HealthPotion> availableHealthPotions = new List<HealthPotion>();
            
            foreach(Item item in player.PlayerInventory.Inventory)
            {
                if (item is HealthPotion)
                {
                    availableHealthPotions.Add((HealthPotion)item);
                }
                 
            }

            bool containsBigHealthPotion = availableHealthPotions.Any(p => p.Name == "Big Healthpotion");
            bool containsNormalHealthPotion = availableHealthPotions.Any(p => p.Name == "Normal Healthpotion");
            bool containsSmallHealthPotion = availableHealthPotions.Any(p => p.Name == "Small Healthpotion");

            int hpToHeal = player.MaxHealth - player.CurrentHealth;
            string appendToStory = "Miljaar, you don't have any healing potions";

            HealthPotion bigHealthPotion = availableHealthPotions.FirstOrDefault(p => p.Name == "Big Healthpotion");
            HealthPotion normalHealthPotion = availableHealthPotions.FirstOrDefault(p => p.Name == "Normal Healthpotion");
            HealthPotion smallHealthPotion = availableHealthPotions.FirstOrDefault(p => p.Name == "Small Healthpotion");

            void UseHealthPotion(HealthPotion potion)
            {
                player.CurrentHealth += potion.HealthRegain;
            }

            void RemovePotionFromInventory(HealthPotion potion)
            {
                player.PlayerInventory.RemoveItem(potion);
            }
            
            if (containsBigHealthPotion == true && hpToHeal >= bigHealthPotion.HealthRegain)
            {
                UseHealthPotion(bigHealthPotion);
                RemovePotionFromInventory(bigHealthPotion);

                appendToStory = string.Format("You replenished {0} health by drinking a {1}", bigHealthPotion.HealthRegain, bigHealthPotion.Name);

            }else if(containsNormalHealthPotion == true && hpToHeal >= normalHealthPotion.HealthRegain)
            {
                UseHealthPotion(normalHealthPotion);
                RemovePotionFromInventory(normalHealthPotion);

                appendToStory = string.Format("You replenished {0} health by drinking a {1}", normalHealthPotion.HealthRegain, normalHealthPotion.Name);

            }
            else if(containsSmallHealthPotion == true && hpToHeal >= smallHealthPotion.HealthRegain)
            {
                UseHealthPotion(smallHealthPotion);
                RemovePotionFromInventory(smallHealthPotion);

                appendToStory = string.Format("You replenished {0} health by drinking a {1}", smallHealthPotion.HealthRegain, smallHealthPotion.Name);

            }
            else
            {
                if(containsSmallHealthPotion == true)
                {
                    UseHealthPotion(smallHealthPotion);
                    RemovePotionFromInventory(smallHealthPotion);

                    appendToStory = string.Format("You replenished {0} health by drinking a {1}", hpToHeal, smallHealthPotion.Name);
                }
                else if(containsNormalHealthPotion == true)
                {
                    UseHealthPotion(normalHealthPotion);
                    RemovePotionFromInventory(bigHealthPotion);

                    appendToStory = string.Format("You replenished {0} health by drinking a {1}", hpToHeal, normalHealthPotion.Name);
                }
                else if(containsBigHealthPotion == true)
                {
                    UseHealthPotion(bigHealthPotion);
                    RemovePotionFromInventory(bigHealthPotion);

                    appendToStory = string.Format("You replenished {0} health by drinking a {1}", hpToHeal, bigHealthPotion.Name);
                }
            }

            return appendToStory + MyStaticClass.WhiteLine();
        }
    }
}