using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class cController : Controller
    {
        //
        // GET: /c/ 
        public JsonResult detail()
        {
            return Json(new {code=1000,obj=new{id=1,name="test"} },JsonRequestBehavior.AllowGet);
        }

    }
}
