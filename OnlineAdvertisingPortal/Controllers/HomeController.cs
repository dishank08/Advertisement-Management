using OnlineAdvertisingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdvertisingPortal.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Mydbcontext db = new Mydbcontext();
            ViewBag.Popular = from t in db.BusinessDetails.OrderByDescending(a => a.Overall) select t;
            return View();
        }

        public ActionResult Catagories()
        {
            
                ViewBag.Message = "Catagories page.";

                return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}