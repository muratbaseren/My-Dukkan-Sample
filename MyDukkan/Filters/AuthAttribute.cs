using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Filters
{
    public class AuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(HttpContext.Current.Session["admin"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}