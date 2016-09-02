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
using MyDukkan.Models;
using MyDukkan.Filters;

namespace MyDukkan.Controllers
{
    [Auth, Exc]
    public class ProductsController : MyController<Products>
    {


        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Categories);
            return View(products.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }


        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products, HttpPostedFileBase product_image)
        {
            if (ModelState.IsValid)
            {
                // http://www.muratbaseren.com/uploads/resim1.jpg
                // c:/inetpub/wwwroot/mysite/uploads/resim1.jpg

                if (System.IO.Directory.Exists(Server.MapPath("~/uploads/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/uploads/"));
                }

                if (product_image != null)
                {
                    product_image.SaveAs(Server.MapPath("~/uploads/" + product_image.FileName));
                    products.ImageFileName = product_image.FileName;
                }

                if (products.StarCount > 5)
                    products.StarCount = 5;

                if (products.StarCount < 0)
                    products.StarCount = 0;

                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products, HttpPostedFileBase product_image)
        {
            if (ModelState.IsValid)
            {
                if (System.IO.Directory.Exists(Server.MapPath("~/uploads/")) == false)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/uploads/"));
                }

                if (product_image != null)
                {
                    product_image.SaveAs(Server.MapPath("~/uploads/" + product_image.FileName));
                    products.ImageFileName = product_image.FileName;
                }

                db.Entry(products).State = EntityState.Modified;

                if (products.StarCount > 5)
                    products.StarCount = 5;

                if (products.StarCount < 0)
                    products.StarCount = 0;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
