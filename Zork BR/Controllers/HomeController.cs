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

            
            theStory.MyStory += "\n" + input;
           

            return View(theStory);
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Rules of the game";

            return View();
        }

        /*
        public ActionResult Add(string input)
        {
            // String komt binnen
            Story theStory = new Story
            {
                MyStory = input
            };
     

            return View(theStory);
        }
        */

        /*
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
}