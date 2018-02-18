using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistProject.Models;

namespace CommunityAssistProject.Controllers
{
    public class LoginController : Controller
    {

        CommunityAssist2017Entities db = new CommunityAssist2017Entities();

        LoginClass lc = new LoginClass();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "UserName, Password")]LoginClass lc)
        {
            int loginResult = db.usp_Login(lc.UserName, lc.Password);
            if (loginResult != -1)
            {
                var uid = (from u in db.People
                           where u.PersonEmail.Equals(lc.UserName)
                           select u.PersonKey).FirstOrDefault();

                int uKey = (int)uid;
                Session["personKey"] = uKey;

                Message msg = new Message();
                msg.MessageText = "Thank You, " + lc.UserName + " for logging in. You can now donate or apply for assistance";

                return RedirectToAction("Result", msg);
            }

            Message loginFailed = new Message();
            loginFailed.MessageText = "Login Failed";
            return View("Result", loginFailed);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}