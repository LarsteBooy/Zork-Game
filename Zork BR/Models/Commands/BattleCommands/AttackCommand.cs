using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Enemies;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands.BattleCommands
{
    public class AttackCommand : Command
    {
        Player player = null;
        Enemy enemy = null;
        Weapon weapon = null;

        public AttackCommand(Player player)
        {
            this.player = player;
            enemy = player.CurrentLocation.Enemy;
            weapon = player.SelectedWeapon;
        }

        public override string MyAction()
        {
            string appendToStory = "";

            enemy.Hp -= weapon.Damage;
            appendToStory += string.Format("You hit the {0} with {1} and did {2} damage" + Environment.NewLine, enemy.Name, weapon.Name, weapon.Damage);

            if(enemy.Hp > 0)
            {
                player.CurrentHealth -= enemy.DamageToPlayer;
                appendToStory += string.Format("The {0} hit you and did {1} damage" + MyStaticClass.WhiteLine(), enemy.Name, enemy.DamageToPlayer);
            }
            
            if (enemy.Hp <= 0)
            {
                enemy.IsDead = true;
                appendToStory += string.Format("You deaded the {0}", enemy.Name + MyStaticClass.WhiteLine());

                MyStaticClass.EnemiesRemaining--;
                player.Kills++;
                player.InBattle = false;
            }
            
            return appendToStory;
        }
    }
}