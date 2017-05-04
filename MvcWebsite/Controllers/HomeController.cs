using System;
using System.Web.Mvc;
using MvcWebsite.Logger;
using MvcWebsite.MessageBroker;

namespace MvcWebsite.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger _logger;
        readonly IMessageBrokerApi _messageBroker;
        public HomeController(ILogger textLogger, IMessageBrokerApi messageBroker)
        {
            _logger = textLogger;
            _messageBroker = messageBroker;
        }

        // GET: Home
        public ActionResult Index()
        {
            var pageComments = _messageBroker.GetPageComments("Index");
            _logger.LogPageVisit(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Index", Request.UserHostAddress));
            return View(pageComments);
        }
    }
}