using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zork_BR.Models;

namespace Zork_BR.Controllers
{
    public class InputController : Controller
    {
        // GET: Input
        static Story theStory = new Story();

        public ActionResult Add(string input)
        {


                theStory.MyStory += "\n" + input;

            return View(theStory);
        }
    }
}