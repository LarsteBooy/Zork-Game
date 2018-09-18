using System;
using System.Web.Mvc;
using Zork_BR.Models;
using Zork_BR.Models.Items;
using Zork_BR.ViewModels;

namespace Zork_BR.Controllers
{
    public class HomeController : Controller
    {
        Story story;
        Map map;
        Player player;
        PlayerStats playerStats;
        StoryViewModel storyViewModel;
        CommandRepository commandRepository;

        //TODO put this field in the playerStats class
        static int sessionId;

        public ActionResult FillDatabase()
        {
            story = new Story();
            map = new Map();
            player = new Player(new Fists());
            playerStats = new PlayerStats();
            player.PlayerInventorySystem = new PlayerInventorySystem();

            
            
            using (var context = ApplicationDbContext.Create())
            {
                context.Stories.Add(story);
                context.Maps.Add(map);
                context.Players.Add(player);
                context.PlayerStats.Add(playerStats);
                context.PlayerInventories.Add(player.PlayerInventorySystem);

                map.BuildMap();
                
                commandRepository = new CommandRepository(story, player, playerStats);
                commandRepository.CreatePlayer();
                story.MyStory += commandRepository.SpawnStory();

                context.SaveChanges();
            }
            Session.Add(sessionId.ToString(), story.Id);
            return RedirectToAction("Index", new { id = story.Id });
        }

        private Object FindInDatabase(string input, int id)
        {
            using(var context = ApplicationDbContext.Create())
            {
                switch (input)
                {
                    case "story": 
                        story = context.Stories.Find(id);
                        return story;
                    case "player":
                        player = context.Players.Find(id);
                        return player;
                    case "map":
                        map = context.Maps.Find(id);
                        return map;
                    case "playerStats":
                        playerStats = context.PlayerStats.Find(id);
                        return playerStats;
                    case "playerInventory":
                        player.PlayerInventorySystem = context.PlayerInventories.Find(id);
                        return player.PlayerInventorySystem;
                    default: return null;
                }
            }
        }
        
        //Index Action
        public ActionResult Index(string input, int id = 0)
        {
            //als nieuw: start game + zet id in session
            //else: haal id uit session en start op

            if (id == 0)
            {
                var gameId = Session[sessionId.ToString()] as int?;
                if (!gameId.HasValue)
                {
                    return RedirectToAction("FillDatabase");
                }
                else
                {
                    story = (Story)FindInDatabase("story", gameId.Value);
                    player = (Player)FindInDatabase("player", gameId.Value);
                    playerStats = (PlayerStats)FindInDatabase("playerStats", gameId.Value);
                    player.PlayerInventorySystem = (PlayerInventorySystem)FindInDatabase("playerInventory", gameId.Value);
                    map = (Map)FindInDatabase("map", gameId.Value);
                }
            }
            else
            {
                story = (Story)FindInDatabase("story", id);
                player = (Player)FindInDatabase("player", id);
                playerStats = (PlayerStats)FindInDatabase("playerStats", id);
                player.PlayerInventorySystem = (PlayerInventorySystem)FindInDatabase("playerInventory", id);
                map = (Map)FindInDatabase("map", id);
            }

            if (input == null)
            {
                storyViewModel = new StoryViewModel(story, player, playerStats);
                return View(storyViewModel);
            }
            
            commandRepository = new CommandRepository(story, player, playerStats);

            using (var context = ApplicationDbContext.Create())
            {
                context.Stories.Attach(story);
                context.Players.Attach(player);
                context.PlayerStats.Attach(playerStats);
                context.PlayerInventories.Attach(player.PlayerInventorySystem);

                if (!player.InBattle)
                {
                    story.MyStory += commandRepository.GetCommandText(input);
                }
                else
                {
                    story.MyStory += commandRepository.GetBattleCommandText(input);
                }
                
                story.MyStory += commandRepository.ExecuteCommand(input);
                story.MyStory += commandRepository.EndOfAction();
                
                context.SaveChanges();

                if (player.CurrentHealth <= 0)
                {
                    return RedirectToAction("GameOver", player);
                }

                if (playerStats.EnemiesRemaining <= 0)
                {
                    return RedirectToAction("GameWon", player);
                }

            }
            
            storyViewModel = new StoryViewModel(story, player, playerStats);

            return View(storyViewModel);
        }

        //Help Action
        public ActionResult Help(int id = 0)
        {
            ViewBag.Message = "Available Commands";

            if (id == 0)
            {
                var gameId = Session[sessionId.ToString()] as int?;

                    story = (Story)FindInDatabase("story", gameId.Value);
                    player = (Player)FindInDatabase("player", gameId.Value);
                    playerStats = (PlayerStats)FindInDatabase("playerStats", gameId.Value);
                    player.PlayerInventorySystem = (PlayerInventorySystem)FindInDatabase("playerInventory", gameId.Value);
                    map = (Map)FindInDatabase("map", gameId.Value);
            }
            else
            {
                story = (Story)FindInDatabase("story", id);
                player = (Player)FindInDatabase("player", id);
                playerStats = (PlayerStats)FindInDatabase("playerStats", id);
                player.PlayerInventorySystem = (PlayerInventorySystem)FindInDatabase("playerInventory", id);
                map = (Map)FindInDatabase("map", id);

            }

            HelpViewModel helpViewModel = new HelpViewModel(player);

            return View(helpViewModel);
        }

        public ActionResult GameOver()
        {
            var gameId = Session[sessionId.ToString()] as int?;
            
            playerStats = (PlayerStats)FindInDatabase("playerStats", gameId.Value);

            AfterGameViewModel gameOverViewModel = new AfterGameViewModel(playerStats);

            sessionId++;

            return View(gameOverViewModel);
        }

        public ActionResult GameWon()
        {
            var gameId = Session[sessionId.ToString()] as int?;
            
            playerStats = (PlayerStats)FindInDatabase("playerStats", gameId.Value);

            AfterGameViewModel gameWonViewModel = new AfterGameViewModel(playerStats);

            sessionId++;

            return View(gameWonViewModel);
        }
    }
}