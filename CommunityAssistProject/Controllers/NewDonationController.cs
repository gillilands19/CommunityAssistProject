using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistProject.Models;

namespace CommunityAssistProject.Controllers
{
    public class NewDonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: NewDonation
        public ActionResult Index()
        {
            if (Session["personKey"] == null)
            {
                Message checkLoginFail = new Message();
                checkLoginFail.MessageText = "Must be logged in to Donate";
                return RedirectToAction("Result", checkLoginFail);
            }
            return View();
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "DonationAmount")] NewDonation newDonation)
        {
            Donation nd = new Donation();

            //get person key from Session Variable
            nd.PersonKey = (int)System.Web.HttpContext.Current.Session["personKey"]; 
            nd.DonationDate = DateTime.Now;
            nd.DonationAmount = newDonation.DonationAmount;
            nd.DonationConfirmationCode = Guid.NewGuid();

            db.Donations.Add(nd);
            db.SaveChanges();

            Message newDonationSuccess = new Message();
            newDonationSuccess.MessageText = "Thank You for your donation";

            return View("Result", newDonationSuccess);

        }

    }
}