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
        static string Vleespoeder = Environment.NewLine; 

        public ActionResult Index(string input)
        {

            if (input != null)
            {
                theStory.MyStory += (input + Vleespoeder);

                if (string.Equals(input, "Poke", StringComparison.OrdinalIgnoreCase) || input.Contains("poke"))
                {
                    theStory.MyStory += (Vleespoeder + "Stop poking me, god dammit" + Vleespoeder + Vleespoeder);
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