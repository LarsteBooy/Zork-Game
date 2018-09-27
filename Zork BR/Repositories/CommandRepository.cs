using System;
using System.Collections.Generic;
using System.Diagnostics;
using Zork_BR.Models;
using Zork_BR.Models.Commands;
using Zork_BR.Models.Utility;
using Zork_BR.Repositories;

namespace Zork_BR.Controllers
{
    public class CommandRepository 
    {
        readonly Story story = null;
        Player player = null;
        readonly PlayerStats playerStats = null;
        

        Dictionary<string, string> Commands = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        Dictionary<string, string> BattleCommands = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public CommandRepository(Story story, Player player, PlayerStats playerStats) {
            this.player = player;
            this.playerStats = playerStats;
            this.story = story;
            FillCommands();
            FillBattleCommands();
        }

        public void CreatePlayer()
        {
            SpawnPlayer();

            void SpawnPlayer()
            {
                player.XCoord = Rng.Next(0, 32);
                player.YCoord = Rng.Next(0, 32);

                Debug.WriteLine("Spawn location = [{0},{1}] which is a {2}", player.YCoord, player.XCoord, Map.map[player.YCoord, player.XCoord].LocationName);

                if (Map.map[player.YCoord, player.XCoord].IsPassable == false)
                {
                    Debug.WriteLine("Spawn location was a non-passable type, initialize respawn");
                    SpawnPlayer(); //Recursion
                }
            }
        }

        public string SpawnStory()
        {
            string spawnStory = "";

            spawnStory += "What? how did you get here? You are in a Plane of some sort with a bunch of people" + Environment.NewLine;
            spawnStory += "Suddenly the hatch below you opens up and you and the others fall through" + Environment.NewLine;
            spawnStory += "You see a island below you and think you are falling to your death but via mysterious ways you survived" + Environment.NewLine;
            spawnStory += String.Format("You landed at a {0}{1}",  Map.map[player.YCoord, player.XCoord].LocationName, MyStaticClass.WhiteLine());
            spawnStory += "Somehow you know the only way to survive is kill everyone else" + MyStaticClass.WhiteLine();

            spawnStory += EndOfAction();

            return spawnStory;
        }

        private void FillCommands()
        {
            Commands.Add("poke", "Stop poking me, god dammit");
            Commands.Add("dance", "You are making a fool of yourself");
            Commands.Add("test", "this is a test");
            Commands.Add("vleespoeder", "ThE bEsT mEaTpOwDeR eVeR");
            Commands.Add("petri", "91%");
            Commands.Add("miljaar", "Harses Lars!");
            Commands.Add("north", "You went north");
            Commands.Add("east", "You went east");
            Commands.Add("south", "You went south");
            Commands.Add("west", "You went west");
            Commands.Add("looknorth", "You look to your north");
            Commands.Add("lookeast", "You look to your east");
            Commands.Add("looksouth", "You look to your south");
            Commands.Add("lookwest", "You look to your west");
            Commands.Add("help", "You need help? Here's a list of commands");
            Commands.Add("1337", "You probably think you're special now huh?");
            Commands.Add("secret", "You are meant to find the fun commands, not just type secret");
            Commands.Add("render", "Rendering more map...");
            Commands.Add("loot", "looting...");
            Commands.Add("inventory", "searching through inventory...");
            Commands.Add("bagspace", "Ultimate hax0r activated; MOAR BAGSPACE !11!!" );
            Commands.Add("status", "Beep Boop. Physic Powers activated");
            Commands.Add("heal", "Ayy lmao, you think you injured, lets drink a potion");
            Commands.Add("equip", "You search your own body for weapons...");
            Commands.Add("drop", "Ayy, so you want to drop things???");
        }

        public void FillBattleCommands()
        {
            BattleCommands.Add("Run", "You try to run away, you pu$$y");
            BattleCommands.Add("Attack", String.Format("Attacking with {0}", player.SelectedWeapon.Name));
            BattleCommands.Add("status", "Beep Boop. Physic Powers activated");
            BattleCommands.Add("heal", "You can't heal during battle. This isn't Skyrim");
            BattleCommands.Add("help", "You need help? Here's a list of commands");
        }

        public string GetCommandText(string input)
        {
            var i = input.Trim();
            string inputString = MyStaticClass.WhiteLine() + "<" + i + ">";
            
            if (Commands.ContainsKey(i))
            {
                var c = Commands[i];
                return inputString + Environment.NewLine + c + MyStaticClass.WhiteLine();
            }
            else
            {
                if(player.InEquipState){
                    return inputString + Environment.NewLine;
                }

                if (player.InDropState)
                {
                    return inputString + Environment.NewLine;
                }

                return inputString + Environment.NewLine + "This is not a command, for all commands see the Help page" + MyStaticClass.WhiteLine();
            }
        }

        public string GetBattleCommandText(string input)
        {
            var i = input.Trim();
            if (BattleCommands.ContainsKey(i))
            {
                var c = BattleCommands[i];
                return MyStaticClass.WhiteLine() + "<" + i + ">" + Environment.NewLine + c + MyStaticClass.WhiteLine();
            }
            else
            {
                return MyStaticClass.WhiteLine() + "<" + i + ">" + Environment.NewLine + "This is not a battlecommand, for all battlecommands see the Help page" + MyStaticClass.WhiteLine();
            }
        }

        public string ExecuteCommand(string input)
        {
            EnemyRepository enemyRepository = new EnemyRepository(player, playerStats);

            //If the player is in battle create a BattleCommandFactory
            if (player.InBattle)
            {
                var battleCommand = BattleCommandFactory.Create(input, story, player, playerStats);
                if(battleCommand != null)
                {
                    string actionString = battleCommand.MyAction();

                    return actionString;
                }
                return "";
            }

            //if the player wants to equip a weapon
            if (player.InEquipState)
            {
                var equipCommand = new EquipCommand(player, input);
                string actionString = equipCommand.MyAction();

                player.InEquipState = false;
                
                return actionString;
            }

            //if the player wants to drop an item
            if (player.InDropState)
            {
                var dropCommand = new DropCommand(player, playerStats, input);
                string actionString = dropCommand.MyAction();

                player.InDropState = false;

                return actionString;
            }

            //If there is no battle going on create a CommandFactory
            var command = CommandFactory.Create(input, story, player, playerStats);
            if (command != null)
            {
                string actionString = command.MyAction();
                
                if(command is DirectionCommand && playerStats.EnemiesRemaining > 0)
                {
                    actionString += enemyRepository.SpawnEnemy();
                    enemyRepository.RandomEnemyDeath();
                }

                return actionString;
            }
            return "";
        }

        public string EndOfAction()
        {
            string endText = "=============================";
            return endText;
        }

    }
}