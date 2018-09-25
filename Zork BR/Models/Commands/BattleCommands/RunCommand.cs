using Zork_BR.Models.Commands.BattleCommands;
using Zork_BR.Models.Utility;
using Zork_BR.Repositories;

namespace Zork_BR.Models.Commands
{
    internal class RunCommand : Command
    {
        Player player = null;
        readonly PlayerStats playerStats = null;

        public RunCommand(Player player, PlayerStats playerStats)
        {
            this.player = player;
            this.playerStats = playerStats;
        }

        public override string MyAction()
        {
            int random = Rng.Next(0, 100);
            if(random < player.CurrentLocation.Enemy.ChanceToRunAwayFromThisEnemy)
            {
                player.InBattle = false;
                player.CurrentLocation.Enemy = null;
                return "You succesfully ran away" + MyStaticClass.WhiteLine();
            }

            string appendToStory = "You Couldn't run Away" + MyStaticClass.WhiteLine();

            AttackCommand attackCommand = new AttackCommand(player, playerStats, true);
            
            return appendToStory + attackCommand.MyAction();
        }
    }
}