using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Extends;

namespace Client.Models
{
    public class UserState
    {
        public static String UserName
        {


            get { return HttpContext.Current.Session["user_name"].ObjToString(); }
            set { HttpContext.Current.Session["user_name"] = value; }
        }

        public static long UserID
        {
            get { return HttpContext.Current.Session["user_id"].ObjToInt(); }
            set { HttpContext.Current.Session["user_id"] = value; }
        }

        public static int UserType
        {
            get { return HttpContext.Current.Session["user_type"].ObjToInt(); }
            set { HttpContext.Current.Session["user_type"] = value; }
        }

        /// <summary>
        /// 清除Session中的所有信息。
        /// </summary>
        public static void Exit()
        {

            HttpContext.Current.Session.RemoveAll();
        }
    }
}