using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork_BR.Models;

namespace Zork_BR.Controllers
{
    public class HomeController : Controller
    {
        static Story theStory = new Story();

        public ActionResult Index(string input)
        {
            //Als input niet leeg is kunnen deze commands worden uitgevoerd
            if (input != null)
            {
                theStory.MyStory += (input + "\n");

                /*
                if (string.Equals(input, "Poke", StringComparison.OrdinalIgnoreCase))
                {
                    theStory.MyStory += ("\nStop poking me, god dammit\n\n");
                }

                if (string.Equals(input, "Dance", StringComparison.OrdinalIgnoreCase))
                {
                    theStory.MyStory += ("\nYou are making a fool of yourself\n\n");
                }
                */

                //De action calls
                switch (true)
                {
                    case bool b when input.Equals("Poke", StringComparison.InvariantCultureIgnoreCase):
                        theStory.MyStory += ("\nStop poking me, god dammit\n\n");
                        //Hier kan een optionele method call komen
                        break;
                    case bool b when input.Equals("Dance", StringComparison.InvariantCultureIgnoreCase):
                        theStory.MyStory += ("\nYou are making a fool of yourself\n\n");
                        break;
                }
            }

            return View(theStory);
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Rules of the game";

            return View();
        }

        /*
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
}