using Client.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        private JsonResult _Json(object data, int code = 0, string msg = null)
        {
            return Json(new { data = data, code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        [Login]
        public ActionResult Add(string str, string name, string sex = null, string ismarr = null, string cardNo = null, string address = null, string workunit = null, string workaddress = null, string job = null, string phone = null)
        {
            try
            {
                new Customer().add(name, sex, ismarr, cardNo, address, workunit, workaddress, job, phone, str,UserState.UserName,UserState.UserID);
            }
            catch (Exception)
            {
                return _Json(null, -100, "系统错误");
            }
            return _Json(null,0, "操作成功");
        }

        [Login(type="admin")]
        public ActionResult GetList(int page = 1, int size = 100)
        {
            try
            {
                var bll = new Customer();
                var data = bll.GetList(page, size);
                var count = bll.GetCount();
                return _Json(new { list=data,count=(count+100-1)/size}, 0, "操作成功");
            }
            catch (Exception)
            { 
                return _Json(null, -100, "系统错误");
            } 
        }

        [Login(type = "admin")]
        public JsonResult DelCustomer(int id)
        {
            try
            {
                var bll = new Customer();
                bll.DelCustomer(id);
                return _Json(null,0, "操作成功");
            }
            catch (Exception)
            {
                return _Json(null, -100, "系统错误");
            } 
        }

        [Login]
        public JsonResult GetListBuyUser(int page = 1, int size = 100)
        {
            try
            {
                var bll = new Customer();
                var data = bll.GetListByUser(UserState.UserID, page, size);
                var count = bll.GetCount(UserState.UserID);
                return _Json(new { list = data, count = (count + 100 - 1) / size }, 0, "操作成功");
            }
            catch (Exception)
            {
                return _Json(null, -100, "系统错误");
            } 
        }

    }
}
