using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using myWebsite.Models;

namespace myWebsite.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Projects()
        {

            return View();

        }

        public ActionResult ContactMe()
        {

            return View();

        }
    }
}