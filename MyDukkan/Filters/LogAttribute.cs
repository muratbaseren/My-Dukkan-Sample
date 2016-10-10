using MyDukkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Filters
{
    public class LogAttribute : FilterAttribute, IActionFilter
    {
        private string GetIP()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();

            return myIP;
        }

        private MyDukkanDBEntities db = new MyDukkanDBEntities();


        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string username = string.Empty;

            if (filterContext.HttpContext.Session["admin"] != null)
            {
                username = (filterContext.HttpContext.Session["admin"] as SiteUsers).Email;
            }

            if (filterContext.HttpContext.Session["kullanici"] != null)
            {
                username = (filterContext.HttpContext.Session["kullanici"] as SiteUsers).Email;
            }

            //db.Logs.Add(new Models.Log()
            //{
            //    Id = Guid.NewGuid(),
            //    AccessDate = DateTime.Now,
            //    IP = GetIP(),
            //    Username = username,
            //    ActionName = filterContext.ActionDescriptor.ActionName,
            //    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            //    Description = "OnActionExecuted"
            //});

            //db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string username = string.Empty;

            if(filterContext.HttpContext.Session["admin"] != null)
            {
                username = (filterContext.HttpContext.Session["admin"] as SiteUsers).Email;
            }

            if (filterContext.HttpContext.Session["kullanici"] != null)
            {
                username = (filterContext.HttpContext.Session["kullanici"] as SiteUsers).Email;
            }

            //db.Logs.Add(new Models.Log() {
            //    Id = Guid.NewGuid(),
            //    AccessDate = DateTime.Now,
            //    IP = GetIP(),
            //    Username = username,
            //    ActionName = filterContext.ActionDescriptor.ActionName,
            //    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            //    Description = "OnActionExecuting"
            //});

            //db.SaveChanges();
        }
    }
}