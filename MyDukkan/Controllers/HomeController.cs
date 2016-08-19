using MyDukkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Controllers
{
    public class HomeController : Controller
    {
        private MyDukkanDBEntities db = new MyDukkanDBEntities();


        public ActionResult AnaSayfa()
        {
            AnaSayfaViewModel model = new AnaSayfaViewModel();
            model.CategoryList = db.Categories.ToList();
            model.ProductList = db.Products.ToList();

            return View(model);
        }

        public ActionResult AnaSayfaByCat(int id)
        {
            AnaSayfaViewModel model = new AnaSayfaViewModel();
            model.CategoryList = db.Categories.ToList();
            model.ProductList = db.Categories.Find(id).Products.ToList();

            return View("AnaSayfa", model);
        }

        public ActionResult UrunDetay(Nullable<int> id)
        {
            SysUser user = new SysUser()
            {
                Id = 1,
                Name = "K.Murat",
                Surname = "Başeren",
                Email = "kadirmuratbaseren@gmail.com",
                Username = "muratbaseren"
            };

            Session["login"] = user;

            // Ürünü bulup model olarak onu göndermelisiniz.

            return View();
        }
    }
}