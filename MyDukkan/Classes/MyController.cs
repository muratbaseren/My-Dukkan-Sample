using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Classes
{
    public class MyController<T> : Controller
    {
        protected MyDukkanDBEntities db = new MyDukkanDBEntities();
        protected CacheManager<T> cm = new CacheManager<T>();
    }
}