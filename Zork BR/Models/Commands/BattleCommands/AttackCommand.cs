using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zork_BR.Models.Enemies;

namespace Zork_BR.Models.Commands.BattleCommands
{
    public class AttackCommand : Command
    {
        Player player = null;
        Enemy enemy = null;

        public AttackCommand(Player player)
        {
            this.player = player;
            enemy = player.CurrentLocation.Enemy;
        }

        public override string MyAction()
        {
            return "Attack succesfull";
        }
    }
}