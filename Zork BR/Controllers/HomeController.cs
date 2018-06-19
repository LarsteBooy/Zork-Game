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
        }

        //Return the given line in the dictionary based on input
        private string GetCommandText(string input)
        {
            FillCommands();

            //Trim the input so that unnecessary spaces given by the player are left out
            var i = input.Trim();

            //Checkt if the dictionary contains the command the player has given.
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

        //Instantiate the story when starting the application, executes only once
        static Story theStory = new Story();

        //Index Action
        public ActionResult Index(string input)
        {
            
            //Append the story with the given storyline based on input
            if (input != null)
            {
                var command = CommandFactory.Create(input);
                if (command != null)
                {
                    command.MyAction();
                }
                theStory.MyStory += GetCommandText(input);
            }

            return View(theStory);
        }

        //Help Action
        public ActionResult Help()
        {
            ViewBag.Message = "Rules of the game";

            return View();
        }
    }
}