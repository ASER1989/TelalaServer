using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.Models;

namespace Client.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        private  JsonResult _Json(object data, int code = 0, string msg = null)
        {
            return Json(new { data = data, code = code, msg = msg },JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult Login(string name, string pwd)
        {
            var result = new Account().Login(name, pwd);
            if (result != null)
            {
                UserState.UserID = result.ID;
                UserState.UserName = result.UserName;
                UserState.UserType = result.Type;
                UserState.UserNickName = result.NickName;
            }
             
            return _Json(result, result == null ? -100 : 0);
        }

        [Login]
        public JsonResult GetUserInfo()
        {
            return _Json(new { ID = UserState.UserID, NickName = UserState.UserNickName, UserName = UserState.UserName });
        }
        public JsonResult AddUser(string name, string pwd,string nickname)
        {
            var result = new Account().Add(name, pwd, nickname);
            return _Json(result, result == null ? -100 : 0);
        }

        [Login]
        public JsonResult UserList()
        {
            var res = new Account().GetUserList();
            return _Json(res);
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult noLogin()
        {
            return _Json(null, -110, "未登陆");
        }

    }
}
