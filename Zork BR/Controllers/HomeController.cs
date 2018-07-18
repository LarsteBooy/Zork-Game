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
            spawnStory += String.Format("You get dropped at the coordinates [{0},{1}] which is a {2}\n", player.YCoord, player.XCoord, Map.map[player.YCoord,player.XCoord].LocationName);
            spawnStory += "You take a good look arround to get your surroundings\n\n";

            spawnStory += NearbyLocations();

            return spawnStory;
        }

        private string NearbyLocations()
        {
            var locationNorth = Map.map[(player.YCoord - 1), player.XCoord].LocationName;
            var locationEast = Map.map[player.YCoord, (player.XCoord + 1)].LocationName;
            var locationSouth = Map.map[(player.YCoord + 1), player.XCoord].LocationName;
            var locationWest = Map.map[player.YCoord, (player.XCoord - 1)].LocationName;

            var nearbyLocations = String.Format("To your north you see a {0}\nTo your east you see a {1}\nTo your south you see a {2}\nTo your west you see a {3}\n\n", locationNorth, locationEast, locationSouth, locationWest);

            return nearbyLocations;
        }

        public void CreatePlayer()
        {
            Random random = new Random();

            SpawnPlayer();

            void SpawnPlayer() {
                player.XCoord = 8;//random.Next(0, 32);
                player.YCoord = 10;//random.Next(0, 32);

                Debug.WriteLine("Spawn location = [{0},{1}] which is a {2}" ,player.YCoord, player.XCoord, Map.map[player.YCoord, player.XCoord].LocationName);

                if (Map.map[player.YCoord, player.XCoord].IsPassable == false)
                {
                    Debug.WriteLine("Spawn location was a non-passable type, initialize respawn");
                    SpawnPlayer(); //Recursion
                }
            }
        }

        Story story = null;
        Map map = null;
        Player player = null;

        public ActionResult FillDatabase()
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

            Session.Add("gameId", story.Id);
            return RedirectToAction("Index", new { id = story.Id });
        }

        private Story FindDatabase(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                story = context.Stories.Find(id);
                map = context.Maps.Find(id);
                player = context.Players.Find(id);
                return story;
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
            Commands.Add("miljaar", "Harses Lars!");
            Commands.Add("north", "You went north");
            Commands.Add("east", "You went east");
            Commands.Add("south", "You went south");
            Commands.Add("west", "You went west");
            Commands.Add("help", "You need help? Here's a list of commands");
            Commands.Add("1337", "You probably think you're special now huh?");
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
                using (var context = ApplicationDbContext.Create())
                { 
                    command.MyAction();
                    story = context.Stories.Find(id);
                    player = context.Players.Find(id);

                    if (command.GetType().Name == "DirectionCommand")
                    {
                        story.MyStory += NearbyLocations();
                    }
                    context.SaveChanges();
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
            Story story = null;
            //als nieuw: start game + zet id in session
            //else: haal id uit session en start op

            if (id == 0)
            {
                var gameId = Session["gameId"] as int?;
                if (!gameId.HasValue)
                {
                    return RedirectToAction("FillDatabase");
                }
                else
                {
                    story = FindDatabase(gameId.Value);
                }
            }
            else
            {
                story = FindDatabase(id);
            }


            //    if(id != 0)
            //  {
            //story = FindDatabase(id);
            // }
            //  else
            // {
            //  /   FillDatabase();
            //}

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