using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebsite.Logger;
using MvcWebsite.MessageBroker;
using MvcWebsite.Models;

namespace MvcWebsite.Controllers
{
    public class ProjectsController : Controller
    {
        ILogger _logger;
        IMessageBrokerApi _messageBroker;
        public ProjectsController(ILogger textLogger, IMessageBrokerApi messageBroker)
        {
            _logger = textLogger;
            _messageBroker = messageBroker;
        }

        public ActionResult Projects()
        {
            var allComments = _messageBroker.GetComments();
            _logger.Log(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Projects", Request.UserHostAddress));
            return View(allComments);
        }
    }
}