using MyDukkan.Classes;
using MyDukkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Controllers
{
    public class HomeController : MyController<Categories>
    {
        public ActionResult AnaSayfa()
        {
            AnaSayfaViewModel model = new AnaSayfaViewModel();

            if (cm.HasCache() == false)
            {
                cm.Set(db.Categories.ToList());
            }

            model.CategoryList = cm.Get();
            model.ProductList = db.Products.ToList();

            return View(model);
        }

        public ActionResult AnaSayfaByCat(int id)
        {
            AnaSayfaViewModel model = new AnaSayfaViewModel();

            if (cm.HasCache() == false)
            {
                cm.Set(db.Categories.ToList());
            }

            model.CategoryList = cm.Get();
            model.ProductList = cm.GetById(x => x.Id == id).Products.ToList();

            return View("AnaSayfa", model);
        }

        public ActionResult UrunDetay(Nullable<int> id)
        {
            if (id == null)
            {
                // id null ise bu hatayı ver.
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Products product = db.Products.Find(id);

            if (product == null)
            {
                // ürün bulunamazsa ise bu hatayı ver.
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }

            UrunDetayViewModel model = new UrunDetayViewModel();
            model.Product = product;

            if (cm.HasCache() == false)
            {
                cm.Set(db.Categories.ToList());
            }

            model.CategoryList = cm.Get();

            return View(model);
        }

        [HttpPost]
        public ActionResult UrunDetay(int? id, UrunDetayViewModel model)
        {
            if (id == null)
            {
                // id null ise bu hatayı ver.
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Products product = db.Products.Find(id);

            if (product == null)
            {
                // ürün bulunamazsa ise bu hatayı ver.
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }

            SiteUsers user = null;

            if (Session["kullanici"] != null)
            {
                user = Session["kullanici"] as SiteUsers;
            }

            if (Session["admin"] != null)
            {
                user = Session["admin"] as SiteUsers;
            }

            Comments comment = new Comments();
            comment.Products = product;
            comment.Nickname = user.Name + " " + user.Surname;
            comment.CreatedOn = DateTime.Now;
            comment.Text = model.CommentOnText;
            comment.IsValid = false;

            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("UrunDetay");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SiteUsers model)
        {
            SiteUsers user =
                db.SiteUsers.Where(x =>
                    x.Email == model.Email &&
                    x.Password == model.Password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.Mesaj = "Geçersiz e-posta ya da şifre";
                return View(model);
            }

            Session.Clear();

            switch (user.Permission.ToLower())
            {
                case "admin":
                    Session["admin"] = user;
                    return RedirectToAction("Index", "Products");

                case "kullanici":
                    Session["kullanici"] = user;
                    return RedirectToAction("AnaSayfa", "Home");

                default:
                    break;
            }

            return RedirectToAction("AnaSayfa", "Home");
        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SiteUsers model)
        {
            // Girilen e-posta adresi daha önce kayıt olmuş mu kontrol edilir.
            SiteUsers user = db.SiteUsers.Where(x => x.Email == model.Email).FirstOrDefault();

            // Kullanıcı nesnesi gelirse kayıtlı demektir.
            if(user != null)
            {
                ViewBag.Error = "E-posta adresi zaten mevcuttur.";

                return View(model);
            }

            model.LastAccess = DateTime.Now;
            model.Permission = "kullanici";

            db.SiteUsers.Add(model);
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("AnaSayfa");
        }





    }
}