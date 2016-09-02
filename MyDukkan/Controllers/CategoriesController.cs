using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDukkan;
using System.Web.Caching;
using MyDukkan.Classes;
using MyDukkan.Models;
using MyDukkan.Filters;

namespace MyDukkan.Controllers
{
    [Auth,Exc]
    public class CategoriesController : MyController<Categories>
    {
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (Session["admin"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("/Home/Login");
        //    }
        //    else
        //    {
        //        if (cm.HasCache() == false)
        //        {
        //            cm.Set(db.Categories.ToList());
        //        }
        //    }

        //    base.OnActionExecuting(filterContext);
        //}

        // GET: Categories
        public ActionResult Index()
        {
            List<Categories> categories = cm.Get();

            if (categories == null)
            {
                // Yoksa veritabanından kategorileri al.
                categories = db.Categories.ToList();

                // Veriler cache 'e atıldı.
                cm.Set(categories);
            }

            return View(categories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categories categories = cm.GetById(x => x.Id == id);

            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categories);
                db.SaveChanges();

                // Veritabanında veri değiştiği için cache güncellenir.
                cm.Set(db.Categories.ToList());

                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categories categories = cm.GetById(x => x.Id == id);

            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories).State = EntityState.Modified;
                db.SaveChanges();

                // Veritabanında veri değiştiği için cache güncellenir.
                cm.Set(db.Categories.ToList());

                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categories categories = cm.GetById(x => x.Id == id);

            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories categories = db.Categories.Find(id);
            db.Categories.Remove(categories);
            db.SaveChanges();

            // Veritabanında veri değiştiği için cache güncellenir.
            cm.Set(db.Categories.ToList());

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
