using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebsite.Settings;
using MvcWebsite.Logger;
using MvcWebsite.MessageBroker;
using MvcWebsite.Models;

namespace MvcWebsite.Controllers
{
    public class CommentController : Controller
    {
        ISettings _settings;
        ILogger _logger;
        IMessageBrokerApi _messageBroker;
        public CommentController(ILogger textLogger, IMessageBrokerApi messageBroker, ISettings settings)
        {
            _settings = settings;
            _logger = textLogger;
            _messageBroker = messageBroker;
        }

        public ActionResult CreateComment(string fromView, string fromController)
        {
            _settings.lastView = fromView;
            _settings.lastController = fromController;
            _logger.Log(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}.", DateTime.Now, "Create Comment", Request.UserHostAddress));
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateComment(CommentModel commentToCreate)
        {
            commentToCreate.Webpage = _settings.lastView;
            _messageBroker.AddComment(commentToCreate);

            return RedirectToAction(_settings.lastView, _settings.lastController);
        }
    }
}