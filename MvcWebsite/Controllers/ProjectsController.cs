using System;
using System.Web.Mvc;
using MvcWebsite.Logger;
using MvcWebsite.MessageBroker;

namespace MvcWebsite.Controllers
{
    public class ProjectsController : Controller
    {
        readonly ILogger _logger;
        readonly IMessageBrokerApi _messageBroker;
        public ProjectsController(ILogger textLogger, IMessageBrokerApi messageBroker)
        {
            _logger = textLogger;
            _messageBroker = messageBroker;
        }

        public ActionResult Projects()
        {
            var pageComments = _messageBroker.GetPageComments("Projects");
            _logger.LogPageVisit(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Projects", Request.UserHostAddress));
            return View(pageComments);
        }
    }
}