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
        ILogger _logger;
        IMessageBrokerApi _messageBroker;
        public CommentController(ILogger textLogger, IMessageBrokerApi messageBroker)
        {
            _logger = textLogger;
            _messageBroker = messageBroker;
        }

        public ActionResult CreateComment()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateComment(CommentModel commentToCreate)
        {
            //_logger.Log(String.Format("Time={0}, PageRequested={1}, RemoteIP={2}, UserNameSubmitted={3}, CommentSubmitted={4}.", DateTime.Now, "Create Comment", Request.UserHostAddress,commentToCreate.UserName.ToString(), commentToCreate.Comment.ToString()));
            _messageBroker.AddComment(commentToCreate);

            switch(commentToCreate.Webpage)
            {
                case "Index":
                    return RedirectToAction(commentToCreate.Webpage,"Home");
                case "Projects":
                    return RedirectToAction(commentToCreate.Webpage,"Projects");
                case "ContactMe":
                    return RedirectToAction(commentToCreate.Webpage,"Contact");
                default:
                    return RedirectToAction("Index","Home");
            }
        }
    }
}