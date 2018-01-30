using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityAssistProject.Models;

namespace CommunityAssistProject.Controllers
{
    public class BusinessRulesController : Controller
    {
        private CommunityAssist2017Entities db = new CommunityAssist2017Entities();

        // GET: BusinessRules
        public ActionResult Index()
        {
            return View(db.BusinessRules.ToList());
        }

        // GET: BusinessRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = db.BusinessRules.Find(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // GET: BusinessRules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessRules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusinessRuleKey,BusinessRuleText")] BusinessRule businessRule)
        {
            if (ModelState.IsValid)
            {
                db.BusinessRules.Add(businessRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessRule);
        }

        // GET: BusinessRules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = db.BusinessRules.Find(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // POST: BusinessRules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusinessRuleKey,BusinessRuleText")] BusinessRule businessRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessRule);
        }

        // GET: BusinessRules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRule businessRule = db.BusinessRules.Find(id);
            if (businessRule == null)
            {
                return HttpNotFound();
            }
            return View(businessRule);
        }

        // POST: BusinessRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessRule businessRule = db.BusinessRules.Find(id);
            db.BusinessRules.Remove(businessRule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
