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

            if (input != null)
            {
                theStory.MyStory += (input + "\n");

                if (string.Equals(input, "Poke", StringComparison.OrdinalIgnoreCase) || input.Contains("poke"))
                {
                    theStory.MyStory += ("\nStop poking me, god dammit\n\n");
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