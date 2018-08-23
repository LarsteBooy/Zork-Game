using System;

namespace Zork_BR.Models.Commands
{
    public class StatusCommand : Command
    {
        Player player = null;

        public StatusCommand(Player player)
        {
            this.player = player;
        }

        public override string MyAction()
        {
            string appendToStory = "";

            appendToStory += string.Format("Health: {0}", player.CurrentHealth);
            appendToStory += Environment.NewLine;
            appendToStory += string.Format("Kills: {0}", "To be implemented");
            appendToStory += Environment.NewLine;
            appendToStory += string.Format("Enemies remaining: {0}", MyStaticClass.EnemiesRemaining);
            appendToStory += Environment.NewLine;
            appendToStory += string.Format("Weapon Equiped: {0}", player.SelectedWeapon.Name);
            appendToStory += MyStaticClass.WhiteLine();

            return appendToStory;
        }
    }
}