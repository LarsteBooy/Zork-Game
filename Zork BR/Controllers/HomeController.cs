using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork_BR.Models;
using Zork_BR.Models.Commands;

namespace Zork_BR.Controllers
{
    public class HomeController : Controller
    {
        Dictionary<string, string> Commands = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        //Add Commands to the Dictionary
        private void FillCommands()
        {
            Commands.Add("poke", "Stop poking me, god dammit");
            Commands.Add("dance", "You are making a fool of yourself");
            Commands.Add("test", "this is a test");
            Commands.Add("vleespoeder", "ThE bEsT mEaTpOwDeR eVeR");
            Commands.Add("Petri", "Onderdanig aan Wouter");
            Commands.Add("Spreadlegs", "I'm ready for your arrival");
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

        Story story = null;
        Map map = null;

        private void CreateDatabase()
        {
            story = new Story();
            map = new Map();

            using (var context = ApplicationDbContext.Create())
            {
                context.Stories.Add(story);
                context.Maps.Add(map);
                context.SaveChanges();
                map.BuildMap();
            }
        }

        private void FindDatabase(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                story = context.Stories.Find(id);
                map = context.Maps.Find(id);
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

        private void ExecuteCommand(string input)
        {
            var command = CommandFactory.Create(input);
            if (command != null)
            {
                command.MyAction();
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
                CreateDatabase();
            }

            if (input == null)
            {
                return View(story);
            }

            ExecuteCommand(input);
            AppendStory(input);

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