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
        //Define a Dictionary (List)
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

        //Return the given line in the dictionary based on input
        private string GetCommandText(string input)
        {
            FillCommands();

            //Trim the input so that unnecessary spaces given by the player are left out
            var i = input.Trim();

            //Check if the dictionary contains the command the player has given.
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

        //Index Action. Voor id als parameter moeten we uiteindelijk iets anders verzinnen. Nu is het niet echt secure.
        public ActionResult Index(string input, int id = 0)
        {
            Story story = null;
            
            Map map = null;

            //create een database als die er nog niet is en voegt een nieuwe storymodel en mapmodel toe 
            if(id != 0)
            {
                using (var context = ApplicationDbContext.Create())
                {
                    story = context.Stories.Find(id);
                    map = context.Maps.Find(id);
                    
                }
            }
           else
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


            //return the view als er niets in de input staat
            if (input == null)
            {
                return View(story);
            }

            //Als playerinput een command is, voer command uit
            var command = CommandFactory.Create(input);
            if (command != null)
            {
                command.MyAction();
            }

            //Append the story with the given storyline based on input
            using (var context = ApplicationDbContext.Create())
            {
                context.Stories.Attach(story);
                story.MyStory += GetCommandText(input);
                context.SaveChanges();
            }

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