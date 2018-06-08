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

            if (theStory.MyStory != "")
            {
                theStory.MyStory += (Environment.NewLine + input);
            }

            //TODO: If input is empty, tell the user to give input/commands

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