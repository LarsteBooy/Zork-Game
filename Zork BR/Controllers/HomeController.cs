using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork_BR.Models;
using Zork_BR.Models.Commands;

namespace Zork_BR.Controllers
{
    public class HomeController : Controller
    {

        private string SpawnStory()
        {
            string spawnStory = "";

            //TODO voeg hier een begin story toe. eventueel met hoe het spel werkt.
            spawnStory += String.Format("You get dropped at the coordinates [{0},{1}] which is a {2}\n", player.YCoord, player.XCoord, Map.map[player.YCoord,player.XCoord].GetType().Name);
            spawnStory += "You take a good look arround to get your surroundings\n\n";

            spawnStory += NearbyLocations();

            return spawnStory;
        }

        private string NearbyLocations()
        {
            var locationNorth = Map.map[(player.YCoord - 1), player.XCoord].GetType().Name;
            var locationEast = Map.map[player.YCoord, (player.XCoord + 1)].GetType().Name;
            var locationSouth = Map.map[(player.YCoord + 1), player.XCoord].GetType().Name;
            var locationWest = Map.map[player.YCoord, (player.XCoord - 1)].GetType().Name;

            var nearbyLocations = String.Format("To your north you see a {0}\nTo your east you see a {1}\nTo your south you see a {2}\nTo your west you see a {3}\n\n", locationNorth, locationEast, locationSouth, locationWest);

            return nearbyLocations;
        }

        public void CreatePlayer()
        {
            Random random = new Random();

            SpawnPlayer();

            void SpawnPlayer() {
                player.XCoord = random.Next(0, 32);
                player.YCoord = random.Next(0, 32);

                Debug.WriteLine("Spawn location = [{0},{1}] which is a {2}" ,player.YCoord, player.XCoord, Map.map[player.YCoord, player.XCoord].GetType().Name);

                if (Map.map[player.YCoord, player.XCoord].GetType().Name == "Ocean")
                {
                    Debug.WriteLine("Spawn location was Ocean, initialize respawn");
                    SpawnPlayer(); //Recursion
                }
            }
        }

        Story story = null;
        Map map = null;
        Player player = null;

        private void FillDatabase()
        {
            story = new Story();
            map = new Map();
            player = new Player();

            using (var context = ApplicationDbContext.Create())
            {
                context.Stories.Add(story);
                context.Maps.Add(map);
                context.Players.Add(player);

                map.BuildMap();
                CreatePlayer(); 
                story.MyStory += SpawnStory();

                context.SaveChanges();
            }
        }

        private void FindDatabase(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                story = context.Stories.Find(id);
                map = context.Maps.Find(id);
                player = context.Players.Find(id);
            }
        }

        Dictionary<string, string> Commands = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        private void FillCommands()
        {
            Commands.Add("poke", "Stop poking me, god dammit");
            Commands.Add("dance", "You are making a fool of yourself");
            Commands.Add("test", "this is a test");
            Commands.Add("vleespoeder", "ThE bEsT mEaTpOwDeR eVeR");
            Commands.Add("Petri", "Onderdanig aan Wouter");
            Commands.Add("spreadlegs", "I'm ready for your arrival");
            Commands.Add("north", "You went north");
            Commands.Add("east", "You went east");
            Commands.Add("south", "You went south");
            Commands.Add("west", "You went west");
        }

        private string GetCommandText(string input)
        {
            FillCommands();

            var i = input.Trim();
            if (Commands.ContainsKey(i))
            {
                var c = Commands[i];
                return "<" + i + ">" + "\n" + c + "\n\n";
            }
            else
            {
                return "<" + i + ">" + "\nThis is not a command, for all commands see the Help page\n\n";
            }
        }

        private void AppendStory(string input)
        {
            using (var context = ApplicationDbContext.Create())
            {
                context.Stories.Attach(story);

                story.MyStory += GetCommandText(input);
                context.SaveChanges();
            }
        }

        private void ExecuteCommand(string input, int id)
        {
            var command = CommandFactory.Create(input, id);
            if (command != null)
            {
                command.MyAction();
                if (command.GetType().Name == "DirectionCommand")
                {
                    using(var context = ApplicationDbContext.Create())
                    {
                        story = context.Stories.Find(id);
                        player = context.Players.Find(id);

                        story.MyStory += NearbyLocations();
                        
                        context.SaveChanges();
                    }
                }
            }
        }

        private void EndOfAction()
        {
            using(var context = ApplicationDbContext.Create())
            {
                context.Stories.Attach(story);
                story.MyStory += "=============================\n\n";
                context.SaveChanges();
            } 
        }

        //Index Action
        public ActionResult Index(string input, int id = 0)
        {
            if(id != 0)
            {
                FindDatabase(id);
            }
           else
            {
                FillDatabase();
            }

            if (input == null)
            {
                return View(story);
            }

            AppendStory(input);
            ExecuteCommand(input, id);
            EndOfAction();

            return View(story);
        }

        //Help Action
        public ActionResult Help()
        {
            ViewBag.Message = "Available Commands";

            return View();
        }
    }
}