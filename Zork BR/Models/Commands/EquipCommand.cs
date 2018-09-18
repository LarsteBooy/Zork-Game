using System;
using System.Collections.Generic;
using System.Linq;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands
{
    public class EquipCommand :Command
    {
        Player player = null;
        readonly string input;

        public EquipCommand(Player player, string input)
        {
            this.player = player;
            this.input = input.ToTitleCase();
        }

        public override string MyAction()
        {
            
            var availableWeapons = player.PlayerInventorySystem.Get<Weapon>();
            
            int howManyWeapons = 1;
            if (!player.InEquipState)
            {
                string appendToStory = string.Format("Which weapon would you like to equip:{0}",  Environment.NewLine);
                
                foreach (Weapon i in availableWeapons)
                {
                    appendToStory += Environment.NewLine + howManyWeapons + ". " + i.Name;
                    howManyWeapons++;
                }

                if(availableWeapons.Count() <= 0)
                {
                    return "You don't have any weapons" + MyStaticClass.WhiteLine();
                }
                else
                {
                    player.InEquipState = true;
                    return appendToStory + MyStaticClass.WhiteLine();
                }
            }

            string weaponEquiped = string.Format("{0} is not a weapon you can equip {1}", input.ToTitleCase(), MyStaticClass.WhiteLine());

            foreach (Weapon weapon in availableWeapons)
            {
                if (weapon.Name.Equals(input))
                {
                    player.SelectedWeapon = weapon;
                    weaponEquiped = string.Format("You equiped {0}", player.SelectedWeapon.Name) + MyStaticClass.WhiteLine();
                }
            }

            return weaponEquiped;

        }
    }
}