using MyDukkan.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Controllers
{
    public class UserController : MyController<Products>
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["kullanici"] == null && Session["admin"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }

            base.OnActionExecuting(filterContext);
        }


        public ActionResult AddBasket(int id)
        {
            List<Tuple<Products, int>> sepetNesnesi = null;

            // Sepet nesnesi session da varsa onu al yoksa yeni oluştur.
            if (Session["basket"] != null)
            {
                sepetNesnesi = Session["basket"] as List<Tuple<Products, int>>;
            }
            else
            {
                sepetNesnesi = new List<Tuple<Products, int>>();
            }

            // Veritabanından sepete eklenecek ürünü bul.
            Products product = db.Products.Where(x => x.Id == id).FirstOrDefault();

            if (product != null)
            {
                // ürün sepette varsa nesnesi elde edilir.
                Tuple<Products, int> sepet_item =
                    sepetNesnesi.Where(x => x.Item1.Id == id).FirstOrDefault();

                if (sepet_item != null)
                {
                    // adet bir değişkene alınır ve 1 arttırılır.
                    int count = sepet_item.Item2 + 1;

                    // sepetteki ürün silinir.
                    sepetNesnesi.Remove(sepet_item);

                    // yeniden yeni adedi ile eklenir.
                    sepetNesnesi.Add(new Tuple<Products, int>(product, count));
                }
                else
                {
                    // ürün sepette yoksa 1 adet şeklinde eklenir.
                    sepetNesnesi.Add(new Tuple<Products, int>(product, 1));
                }

            }

            Session["basket"] = sepetNesnesi;

            // Seni çağıran sayfa(Request.UrlReferrer) yönlen..
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ShowBasket()
        {
            List<Tuple<Products, int>> sepetNesnesi = null;

            if (Session["basket"] != null)
            {
                sepetNesnesi = Session["basket"] as List<Tuple<Products, int>>;
            }
            else
            {
                sepetNesnesi = new List<Tuple<Products, int>>();
            }

            return View(sepetNesnesi);
        }

        public ActionResult RemoveBasket(int id)
        {
            List<Tuple<Products, int>> sepetNesnesi = null;

            if (Session["basket"] != null)
            {
                sepetNesnesi = Session["basket"] as List<Tuple<Products, int>>;
            }
            else
            {
                sepetNesnesi = new List<Tuple<Products, int>>();
            }

            Tuple<Products, int> sepet_item =
                sepetNesnesi.Where(x => x.Item1.Id == id).FirstOrDefault();

            sepetNesnesi.Remove(sepet_item);

            Session["basket"] = sepetNesnesi;

            return RedirectToAction("ShowBasket");
        }

        public ActionResult IncreaseCount(int id)
        {
            List<Tuple<Products, int>> sepetNesnesi = null;

            if (Session["basket"] != null)
            {
                sepetNesnesi = Session["basket"] as List<Tuple<Products, int>>;
            }
            else
            {
                sepetNesnesi = new List<Tuple<Products, int>>();
            }

            Tuple<Products, int> sepet_item =
                sepetNesnesi.Where(x => x.Item1.Id == id).FirstOrDefault();

            // adet bir değişkene alınır ve 1 arttırılır.
            int count = sepet_item.Item2 + 1;
            Products product = sepet_item.Item1;

            // sepetteki ürün silinir.
            sepetNesnesi.Remove(sepet_item);

            // yeniden yeni adedi ile eklenir.
            sepetNesnesi.Add(new Tuple<Products, int>(product, count));

            Session["basket"] = sepetNesnesi;

            return RedirectToAction("ShowBasket");
        }

        public ActionResult DecreaseCount(int id)
        {
            List<Tuple<Products, int>> sepetNesnesi = null;

            if (Session["basket"] != null)
            {
                sepetNesnesi = Session["basket"] as List<Tuple<Products, int>>;
            }
            else
            {
                sepetNesnesi = new List<Tuple<Products, int>>();
            }

            Tuple<Products, int> sepet_item =
                sepetNesnesi.Where(x => x.Item1.Id == id).FirstOrDefault();

            // adet bir değişkene alınır ve 1 azaltılı.
            int count = sepet_item.Item2 - 1;
            Products product = sepet_item.Item1;

            // sepetteki ürün silinir.
            sepetNesnesi.Remove(sepet_item);

            // yeniden yeni adedi ile eklenir.
            sepetNesnesi.Add(new Tuple<Products, int>(product, count));

            Session["basket"] = sepetNesnesi;

            return RedirectToAction("ShowBasket");
        }

        public ActionResult Profil()
        {
            SiteUsers user = null;

            if (Session["kullanici"] != null)
            {
                user = Session["kullanici"] as SiteUsers;
            }

            if (Session["admin"] != null)
            {
                user = Session["admin"] as SiteUsers;
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Profil(SiteUsers model)
        {
            SiteUsers user = db.SiteUsers.FirstOrDefault(x => x.Id == model.Id);

            if (user != null)
            {
                user.LastAccess = DateTime.Now;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Password = model.Password;

                db.SaveChanges();

                if(Session["kullanici"] != null)
                {
                    Session["kullanici"] = user;
                }

                if (Session["admin"] != null)
                {
                    Session["admin"] = user;
                }

                ViewBag.Message = "Profiliniz güncellenmiştir.";
            }

            return View(model);
        }

    }
}