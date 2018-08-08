using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Items;
using Zork_BR.Models.Utility;

namespace Zork_BR.Models.Locations
{
    public class Cabin : Location, ILocationInventory
    {
        public override string LocationName => "Cabin";

        public override bool IsPassable => true;
        public override bool IsLootable => true;
        public override bool HasLoot{ get;set; }

        public ICollection<Item> Inventory { get ; set ; }

        private const string locationDescriptionDefault = "You see a cabin filled with epic lewt.";

        public Cabin(string locationDescription = locationDescriptionDefault)
        {
            LocationDescription = locationDescription;
            Inventory = new List<Item>();

            //70% chance it contains loot
            int random = Rng.Next(0, 10);
            HasLoot = random < 7;
            
            //Build inventory
            if(HasLoot)
            {
                int chanceForHealth = Rng.Next(0, 100); //75% chance for a healthpotion
                if(chanceForHealth < 75)
                {
                    int whichPotion = Rng.Next(0, 100);
                    if(whichPotion < 60)    //60% chance for SmallHealthPotion
                    {
                        Inventory.Add(new SmallHealthPotion());
                    }
                    else if(whichPotion >= 60 && whichPotion < 90) //30% chance for NormalHealthPotion
                    {
                        Inventory.Add(new NormalHealthPotion());
                    }
                    else
                    {
                        Inventory.Add(new BigHealthPotion()); //10% chance for BigHealthPotion
                    }
                }
            }
        }
    }
}