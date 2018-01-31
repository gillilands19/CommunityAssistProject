using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistProject.Models;

namespace CommunityAssistProject.Controllers
{
    public class RegistrationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();

        NewPerson newPerson = new NewPerson();

        // GET: Registration
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        public ActionResult Success()
        { 
            Message successMessage = new Message();
            successMessage.MessageText = "Registration Successful";
            return View("result", successMessage);
        }

        public ActionResult Failure()
        {
            Message failureMessage = new Message();
            failureMessage.MessageText = "Registration Failed";
            return View("result", failureMessage);
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include ="lastname, firstname, email, password, apartmentNumber, street, city, state, zipcode, phone")]NewPerson newPerson)
        {
            int result = db.usp_Register(newPerson.LastName, newPerson.FirstName, newPerson.Email, newPerson.PlainPassword, newPerson.ApartmentNumber , newPerson.Street, newPerson.City, newPerson.State, newPerson.ZipCode, newPerson.Phone);

            if (result != -1)
            {
                return RedirectToAction("Success");
            }

            return RedirectToAction("Failure");
        }

    }
}