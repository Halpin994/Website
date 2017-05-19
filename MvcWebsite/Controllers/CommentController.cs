using System;
using System.Web.Mvc;

using MvcWebsite.Logger;
using MvcWebsite.MessageBroker;
using MvcWebsite.Models;

namespace MvcWebsite.Controllers
{
    public class CommentController : Controller
    {
        readonly ILogger _logger;
        readonly IMessageBrokerApi _messageBroker;
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
            _messageBroker.AddComment(commentToCreate);
            _logger.LogComment(String.Format("Time = {0}, RemoteIP = {1}, Page = {2}, UserName = {3}, Comment = {4}", DateTime.Now, Request.UserHostAddress, commentToCreate.Webpage, commentToCreate.UserName,commentToCreate.Comment));

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