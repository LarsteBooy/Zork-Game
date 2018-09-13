using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
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
            //Create list with all available weapons the player has
            List<Weapon> availableWeapons = new List<Weapon>();
            int howManyWeapons = 1;

            foreach (Item item in Player.inventoryPlayer.Inventory)
            {
                if (item is Weapon)
                {
                    availableWeapons.Add((Weapon)item);
                }
            }

            if (!player.InEquipState)
            {
                string appendToStory = string.Format("Which weapon would you like to equip:{0}",  Environment.NewLine);
                
                var sortedList = availableWeapons.OrderBy(x => x.Name);

                foreach (Weapon i in availableWeapons)
                {
                    appendToStory += Environment.NewLine + howManyWeapons + ". " + i.Name;
                    howManyWeapons++;
                }

                if(availableWeapons.Count <= 0)
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