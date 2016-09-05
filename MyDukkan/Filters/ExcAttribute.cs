using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Filters
{
    public class ExcAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Controller.TempData["last_error"] = filterContext.Exception;
            filterContext.Result = new RedirectResult("/Home/Error");
        }
    }
}