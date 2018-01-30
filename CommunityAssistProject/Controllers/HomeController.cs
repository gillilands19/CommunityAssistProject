using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistProject.Models;

namespace CommunityAssistProject.Controllers
{
    public class HomeController : Controller
    {
        private CommunityAssist2017Entities db = new CommunityAssist2017Entities();

        public ActionResult Index()
        {
            return View(db.GrantTypes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}