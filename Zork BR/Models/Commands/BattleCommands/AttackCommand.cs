using System;
using Zork_BR.Models.Enemies;
using Zork_BR.Models.Items;

namespace Zork_BR.Models.Commands.BattleCommands
{
    public class AttackCommand : Command
    {
        Player player = null;
        PlayerStats playerStats = null;
        Enemy enemy = null;
        Weapon weapon = null;

        public AttackCommand(Player player, PlayerStats playerStats)
        {
            this.player = player;
            this.playerStats = playerStats;
            enemy = player.CurrentLocation.Enemy;
            weapon = player.SelectedWeapon;
        }

        public override string MyAction()
        {
            string appendToStory = "";

            int weaponDamage = weapon.Damage;

            enemy.Hp -= weaponDamage;
            appendToStory += string.Format("You hit the {0} with {1} and did {2} damage. The {0} has {3} hp remaining" + Environment.NewLine, enemy.Name, weapon.Name, weaponDamage, enemy.Hp);
            
            if (enemy.Hp > 0)
            {
                int damageToPlayer = enemy.DamageToPlayer;

                player.CurrentHealth -= damageToPlayer;
                appendToStory += string.Format("The {0} hit you and did {1} damage" + MyStaticClass.WhiteLine(), enemy.Name, damageToPlayer);
            }
            else
            {
                enemy.IsDead = true;
                appendToStory += string.Format("You deaded the {0}", enemy.Name + MyStaticClass.WhiteLine());

                playerStats.EnemiesRemaining--;
                playerStats.Kills++;
                player.InBattle = false;
                player.CurrentLocation.Enemy = null; //Remove Enemy from location
            }

            return appendToStory;
        }
    }
}