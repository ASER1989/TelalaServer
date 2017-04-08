using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return _Json(result, result == null ? -100 : 0);
        }
        public JsonResult AddUser(string name, string pwd,string nickName)
        {
            var result = new Account().Add(name, pwd, nickName);
            return _Json(result, result == null ? -100 : 0);
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
