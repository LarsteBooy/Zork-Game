﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Items;
using Zork_BR.Models.Locations;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Commands
{
    public class LootCommand : Command
    {
        private readonly string input;
        private readonly Story story = null;
        private readonly Player player = null;
        
        public LootCommand(string input, Story story, Player player)
        {
            this.input = input;
            this.story = story;
            this.player = player;
        }
        /*
        //Build inventory
        private void BuildInventory()
        {
            int chanceForHealth = Rng.Next(0, 100); //75% chance for a healthpotion
            if(chanceForHealth< 75)
            {
                int whichPotion = Rng.Next(0, 100);
                if(whichPotion< 60)    //60% chance for SmallHealthPotion
                {
                    player.CurrentLocation.Inventory.Add(new SmallHealthPotion());
                }
                else if(whichPotion >= 60 && whichPotion< 90) //30% chance for NormalHealthPotion
                {
                    player.CurrentLocation.Inventory.Add(new NormalHealthPotion());
                }
                else
                {
                    player.CurrentLocation.Inventory.Add(new BigHealthPotion()); //10% chance for BigHealthPotion
                }
            }
        }
        */

        public override string MyAction()
        {
            string appendToStory = "";

            if (player.CurrentLocation.IsLootable == true) {
                
                
                if(player.CurrentLocation.HasLoot == true)
                {
                    //BuildInventory();
                    //Code om inventory van location te doorzoeken
                    if (player.CurrentLocation is ILocationInventory location)
                    {
                        Console.WriteLine(string.Join(";", location.Inventory));
                    }


                    //if Items are found
                    appendToStory += "You found ..." + MyStaticClass.WhiteLine();

                    player.CurrentLocation.HasLoot = false;
                }
                else
                {
                     appendToStory += "This place was already looted" + MyStaticClass.WhiteLine();
                }
                
                return appendToStory;
            }
            else
            {
                return "You can't loot here" + MyStaticClass.WhiteLine();
            }
        }
    }
}