﻿using System;
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
        

        Dictionary<string, string> Commands = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        Dictionary<string, string> BattleCommands = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public CommandRepository(Story story, Player player) {
            this.player = player;
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

            //TODO voeg hier een begin story toe. eventueel met hoe het spel werkt.
            spawnStory += String.Format("You get dropped at the coordinates [{0},{1}] which is a {2}" + Environment.NewLine, player.YCoord, player.XCoord, Map.map[player.YCoord, player.XCoord].LocationName);
            spawnStory += "You take a good look arround to get your surroundings" + Environment.NewLine + Environment.NewLine;

            spawnStory += /*NearbyLocations() +*/ EndOfAction();

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
            Commands.Add("help", "You need help? Here's a list of commands");
            Commands.Add("1337", "You probably think you're special now huh?");
            Commands.Add("secret", "You are meant to find the fun commands, not just type secret");
            Commands.Add("render", "Rendering more map...");
            Commands.Add("loot", "looting...");
            Commands.Add("inventory", "searching through inventory...");
            Commands.Add("bagspace", "Ultimate hax0r activated; MOAR BAGSPACE !11!!" );
            Commands.Add("status", "Beep Boop. Physic Powers activated");
        }

        public void FillBattleCommands()
        {
            BattleCommands.Add("Run", "You try to run away, you pu$$y");
            BattleCommands.Add("Attack", String.Format("Attacking with {0}", player.SelectedWeapon.Name));
            BattleCommands.Add("status", "Beep Boop. Physic Powers activated");
        }

        public string GetCommandText(string input)
        {
            var i = input.Trim();
            if (Commands.ContainsKey(i))
            {
                var c = Commands[i];
                return MyStaticClass.WhiteLine() + "<" + i + ">" + Environment.NewLine + c + MyStaticClass.WhiteLine();
            }
            else
            {
                return MyStaticClass.WhiteLine() + "<" + i + ">" + Environment.NewLine + "This is not a command, for all commands see the Help page" + MyStaticClass.WhiteLine();
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

        /*
        public string NearbyLocations()
        {
            var locationNorth = Map.map[(player.YCoord - 1), player.XCoord].LocationName;
            var locationEast = Map.map[player.YCoord, (player.XCoord + 1)].LocationName;
            var locationSouth = Map.map[(player.YCoord + 1), player.XCoord].LocationName;
            var locationWest = Map.map[player.YCoord, (player.XCoord - 1)].LocationName;

            var nearbyLocations = String.Format("To your north you see a {0}" + Environment.NewLine + 
                                                "To your east you see a {1}" + Environment.NewLine + 
                                                "To your south you see a {2}" + Environment.NewLine + 
                                                "To your west you see a {3}" + MyStaticClass.WhiteLine(), 
                                                locationNorth, locationEast, locationSouth, locationWest
                                                );
            return nearbyLocations;
        }
        */

        public string ExecuteCommand(string input)
        {
            EnemyRepository enemyRepository = new EnemyRepository(player);

            //If the player is in battle create a BattleCommandFactory
            if (player.InBattle)
            {
                var battleCommand = BattleCommandFactory.Create(input, story, player);
                if(battleCommand != null)
                {
                    string actionString = battleCommand.MyAction();

                    return actionString;
                }
                return "";
            }

            //If there is no battle going on create a CommandFactory
            var command = CommandFactory.Create(input, story, player);
            if (command != null)
            {
                string actionString = command.MyAction();

                //TODO dit zetten in de homecontroller voor cleaner code.
                if(command is DirectionCommand && MyStaticClass.EnemiesRemaining > 0)
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