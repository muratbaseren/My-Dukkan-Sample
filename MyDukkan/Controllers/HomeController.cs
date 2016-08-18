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
        public ActionResult AnaSayfa()
        {
            // Bütün ürünler sayfaya gönderilmeli.

            return View();
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