using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDukkan;
using MyDukkan.Classes;

namespace MyDukkan.Controllers
{
    public class SiteUsersController : MyController<SiteUsers>
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admin"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }

            base.OnActionExecuting(filterContext);
        }

        // GET: SiteUsers
        public ActionResult Index()
        {
            return View(db.SiteUsers.ToList());
        }

        // GET: SiteUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUsers siteUsers = db.SiteUsers.Find(id);
            if (siteUsers == null)
            {
                return HttpNotFound();
            }
            return View(siteUsers);
        }

        // GET: SiteUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteUsers siteUsers)
        {
            siteUsers.LastAccess = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.SiteUsers.Add(siteUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteUsers);
        }

        // GET: SiteUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUsers siteUsers = db.SiteUsers.Find(id);
            if (siteUsers == null)
            {
                return HttpNotFound();
            }
            return View(siteUsers);
        }

        // POST: SiteUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteUsers siteUsers)
        {
            siteUsers.LastAccess = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(siteUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteUsers);
        }

        // GET: SiteUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUsers siteUsers = db.SiteUsers.Find(id);
            if (siteUsers == null)
            {
                return HttpNotFound();
            }
            return View(siteUsers);
        }

        // POST: SiteUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteUsers siteUsers = db.SiteUsers.Find(id);
            db.SiteUsers.Remove(siteUsers);
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
