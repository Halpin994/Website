using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using myWebsite.Logger;
using myWebsite.Settings;

namespace myWebsite.Controllers
{
    public class HomeController : Controller
    {
        ILogger _logger;
        public HomeController(ILogger textLogger)
        {
            _logger = textLogger;
        }

        // GET: Home
        public ActionResult Index()
        {
            _logger.Log(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Index", Request.UserHostAddress));
            return View();
        }

        public ActionResult Projects()
        {
            _logger.Log(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Projects", Request.UserHostAddress));
            return View();

        }

        public ActionResult ContactMe()
        {
            _logger.Log(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Contact Me", Request.UserHostAddress));
            return View();

        }
    }
}