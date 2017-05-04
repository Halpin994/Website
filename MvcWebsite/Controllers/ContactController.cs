using System;
using System.Web.Mvc;
using MvcWebsite.Logger;
using MvcWebsite.MessageBroker;

namespace MvcWebsite.Controllers
{
    public class ContactController : Controller
    {
        readonly ILogger _logger;
        readonly IMessageBrokerApi _messageBroker;
        public ContactController(ILogger textLogger, IMessageBrokerApi messageBroker)
        {
            _logger = textLogger;
            _messageBroker = messageBroker;
        }

        public ActionResult ContactMe()
        {
            var pageComments = _messageBroker.GetPageComments("ContactMe");
            _logger.LogPageVisit(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Contact Me", Request.UserHostAddress));
            return View(pageComments);

        }
    }
}