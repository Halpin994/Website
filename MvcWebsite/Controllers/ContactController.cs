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
    public class ContactController : Controller
    {
        ILogger _logger;
        IMessageBrokerApi _messageBroker;
        public ContactController(ILogger textLogger, IMessageBrokerApi messageBroker)
        {
            _logger = textLogger;
            _messageBroker = messageBroker;
        }

        public ActionResult ContactMe()
        {
            var pageComments = _messageBroker.GetPageComments("ContactMe");
            _logger.Log(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Contact Me", Request.UserHostAddress));
            return View(pageComments);

        }
    }
}