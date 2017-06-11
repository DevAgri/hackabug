using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackaBug.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Json(new {msg = "Aplicação iniciada"},JsonRequestBehavior.AllowGet);
        }
    }
}
