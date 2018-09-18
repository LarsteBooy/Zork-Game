﻿using System.Collections.Generic;
using System.Linq;
using Zork_BR.Models.Items.Consumables;

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
            var availableHealthPotions = player.PlayerInventorySystem.Get<HealthPotion>();
            
            bool containsBigHealthPotion = availableHealthPotions.Any(p => p is BigHealthPotion);
            bool containsNormalHealthPotion = availableHealthPotions.Any(p => p is NormalHealthPotion);
            bool containsSmallHealthPotion = availableHealthPotions.Any(p => p is SmallHealthPotion);

            int hpToHeal = player.MaxHealth - player.CurrentHealth;
            string appendToStory = "Miljaar, you don't have any healing potions";

            HealthPotion bigHealthPotion = (BigHealthPotion)availableHealthPotions.FirstOrDefault(p => p is BigHealthPotion);
            HealthPotion normalHealthPotion = (NormalHealthPotion)availableHealthPotions.FirstOrDefault(p => p is NormalHealthPotion);
            HealthPotion smallHealthPotion = (SmallHealthPotion)availableHealthPotions.FirstOrDefault(p => p is SmallHealthPotion);

            void UseHealthPotion(HealthPotion potion)
            {
                player.CurrentHealth += potion.HealthRegain;
            }

            void RemovePotionFromInventory(HealthPotion potion)
            {
                player.PlayerInventorySystem.RemoveItem(potion);
            }
            
            if(hpToHeal == 0)
            {
                return "Ayy you thought wrong. You have full health" + MyStaticClass.WhiteLine();
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
            else if(hpToHeal > 0)
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
                    RemovePotionFromInventory(normalHealthPotion);

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