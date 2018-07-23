﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork_BR.Models;
using Zork_BR.Models.Commands;
using Zork_BR.ViewModels;

namespace Zork_BR.Controllers
{
    public class HomeController : Controller
    {
        Story story;
        Map map;
        Player player;
        StoryViewModel storyViewModel;
        StoryRepository storyRepository;

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
                
                storyRepository = new StoryRepository(story, player);
                storyRepository.CreatePlayer();
                story.MyStory += storyRepository.SpawnStory();

                context.SaveChanges();
            }
            Session.Add("gameId", story.Id);
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
                var gameId = Session["gameId"] as int?;
                if (!gameId.HasValue)
                {
                    return RedirectToAction("FillDatabase");
                }
                else
                {
                    story = (Story)FindInDatabase("story", gameId.Value);
                    player = (Player)FindInDatabase("player", gameId.Value);
                    map = (Map)FindInDatabase("map", gameId.Value);
                }
            }
            else
            {
                story = (Story)FindInDatabase("story", id);
                player = (Player)FindInDatabase("player", id);
                map = (Map)FindInDatabase("map", id);
            }

            if (input == null)
            {
                storyViewModel = new StoryViewModel(story, player);
                return View(storyViewModel);
            }
            
            storyRepository = new StoryRepository(story, player);

            using (var context = ApplicationDbContext.Create())
            {
                context.Stories.Attach(story);
                context.Players.Attach(player);
                story.MyStory += storyRepository.GetCommandText(input);
                story.MyStory += storyRepository.ExecuteCommand(input, id);
                story.MyStory += storyRepository.EndOfAction();
                
                context.SaveChanges();

            }
            
            storyViewModel = new StoryViewModel(story, player);

            return View(storyViewModel);
        }

        //Help Action
        public ActionResult Help()
        {
            ViewBag.Message = "Available Commands";

            return View();
        }
    }
}