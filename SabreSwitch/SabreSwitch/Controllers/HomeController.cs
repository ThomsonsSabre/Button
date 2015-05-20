using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabreSwitch.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult okGo(string btOkGo)
        {
            if (Session["EndDate"] == null)
            {
                Session["EndDate"] = DateTime.Now.AddMinutes(1).ToString("dd-MM-yyyy hh:mm:ss tt");
            }
            ViewBag.Message = "Countdown";
            ViewBag.EndDate = Session["EndDate"];
            return View("okGoResponse");            
        }

    }
}
