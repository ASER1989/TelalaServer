using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class TsController : Controller
    {
        //
        // GET: /Ts/

        public JsonResult addGoods(string name, string gtypeId, string price, string artno)
        {
            var file =Request.Files;
            return Json("");
        }

    }
}
