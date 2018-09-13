using System;

namespace Zork_BR.Models.Commands
{
    public class StatusCommand : Command
    {
        Player player = null;
        PlayerStats playerStats = null;

        public StatusCommand(Player player, PlayerStats playerStats)
        {
            this.player = player;
            this.playerStats = playerStats;
        }

        public override string MyAction()
        {
            string appendToStory = "";

            appendToStory += string.Format("Health: {0}", player.CurrentHealth);
            appendToStory += Environment.NewLine;
            appendToStory += string.Format("Max Health: {0}", player.MaxHealth);
            appendToStory += Environment.NewLine;
            appendToStory += string.Format("Kills: {0}", playerStats.Kills);
            appendToStory += Environment.NewLine;
            appendToStory += string.Format("Enemies remaining: {0}", playerStats.EnemiesRemaining);
            appendToStory += Environment.NewLine;
            appendToStory += string.Format("Weapon Equiped: {0}", player.SelectedWeapon.Name);
            appendToStory += MyStaticClass.WhiteLine();

            return appendToStory;
        }
    }
}