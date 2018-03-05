using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistProject.Models;
namespace CommunityAssistProject.Controllers
{
    public class GrantApplicationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: GrantApplication
        public ActionResult Index()
        {
            if (Session["personKey"] == null)
            {
                Message notLoggedIn = new Message();
                notLoggedIn.MessageText = "You must be logged in to apply for assistance.";
                return RedirectToAction("Result", notLoggedIn);
            }

            ViewBag.GrantTypeKey = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = 
            "GrantApplicationKey, PersonKey, GrantAppicationDate, GrantTypeKey, GrantApplicationRequestAmount, GrantApplicationReason, GrantApplicationStatusKey, GrantApplicationAllocationAmount")]GrantApplication newGrantApplication)
        {
            newGrantApplication.PersonKey = (int)System.Web.HttpContext.Current.Session["personKey"];
            newGrantApplication.GrantAppicationDate = DateTime.Now;
            newGrantApplication.GrantApplicationStatusKey = 1;
            db.GrantApplications.Add(newGrantApplication);
            db.SaveChanges();

            Message applicationProcessing = new Message();
            applicationProcessing.MessageText = "Thank you for Applying for assistance. Your Application is Processing.";
            return View("Result", applicationProcessing);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }

    }
}