using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client
{

    public class LoginAttribute : ActionFilterAttribute
    {
        public string type { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            int UserID = UserState.UserID;
            //string userName = filterContext.HttpContext.Session["user_name"].ObjToString();
            // string userID = filterContext.HttpContext.Session["user_name"].ObjToString();
            if (UserID <= 0)
            {
                filterContext.HttpContext.Response.Redirect("/index/noLogin");
                filterContext.Result = new ContentResult();
            }
            if (type == "admin" && UserState.UserType != 0)
            {
                filterContext.HttpContext.Response.Redirect("/index/noRole");
                filterContext.Result = new ContentResult();
            }
        }
    }
     
}