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
        }
    }

    //public class CmsLoginAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        base.OnActionExecuting(filterContext);

    //        int userid = UserState.SysUserID;
    //        if (userid <= 0)
    //        {
    //            if (!_requstLogin(filterContext))
    //            {
    //                filterContext.HttpContext.Response.Redirect("/Cms/NoLogin");
    //                filterContext.Result = new ContentResult();
    //            }

    //        }
    //    }

    //    private bool _requstLogin(ActionExecutingContext filterContext)
    //    {
    //        string openid = filterContext.RequestContext.HttpContext.Request["openid"];
    //        string passport = filterContext.RequestContext.HttpContext.Request["passport"];

    //        if (openid == null || openid.Trim() == "" || passport == null || passport == "")
    //        {
    //            return false;
    //        }

    //        //var res = new AdminBLL().OpenLogin(openid.ToLower(), passport.ToLower());
    //        //if (res != null)
    //        //{
    //        //    UserState.SysUserID = res.ID;
    //        //    UserState.UserName = res.Name;
    //        //    return true;
    //        //}

    //        return false;
    //    }
    //} 
}