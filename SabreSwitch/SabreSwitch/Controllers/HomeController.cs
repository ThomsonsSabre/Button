using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SabreSwitch.Models;

namespace SabreSwitch.Controllers
{
    public class HomeController : Controller
    {
        private ButtonClickContext db = new ButtonClickContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult okGo(string btOkGo)
        {
            UpdateDB();
           
            if (Session["EndDate"] == null)
            {
                Session["EndDate"] = DateTime.Now.AddMinutes(1).ToString("dd-MM-yyyy hh:mm:ss tt");
            }
            ViewBag.Message = "Countdown";
            ViewBag.EndDate = Session["EndDate"];
            return View("okGoResponse");            
        }

        public void UpdateDB()
        {
            if (ModelState.IsValid)
            {
                Guid guid = Guid.NewGuid();

                ButtonClick buttonClick = new ButtonClick()
                {
                    UID = guid.ToString(),
                    ClickDateTime = DateTime.Now
                };

                if (ModelState.IsValid)
                {
                    db.Clicks.Add(buttonClick);
                    db.SaveChanges();
                }
            }
        }

        public ActionResult Games(string btGames)
        {
            return View("Games");
        }

    }
}
