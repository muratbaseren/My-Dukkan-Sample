using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDukkan.Classes
{
    public static class MyHelpers
    {
        public static MvcHtmlString Button(this HtmlHelper helper,  string actionName, string controllerName, string className, string iconName, string text)
        {
            // <a href='/Categories/Create' class='btn btn-primary'><span class='glyphicon glyphicon-plus'></span> Create New</a>

            string html =
                string.Format("<a href='/{0}/{1}' class='btn btn-{2}'><span class='glyphicon glyphicon-{3}'></span> {4}</a>",
                    controllerName, actionName, className, iconName, text);

            return new MvcHtmlString(html);
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string actionName, string controllerName, string className, string text)
        {
            // <a href='/Categories/Create' class='btn btn-primary'>Create New</a>

            string html =
                string.Format("<a href='/{0}/{1}' class='btn btn-{2}'>{3}</a>",
                    controllerName, actionName, className, text);

            return new MvcHtmlString(html);
        }

        public static MvcHtmlString InputButton(this HtmlHelper helper, string text, string buttonType, string className)
        {
            string html =
                string.Format("<button type='{0}' class='btn btn-{1}'>{2}</button>",
                                buttonType,className, text);

            return new MvcHtmlString(html);
        }
    }
}