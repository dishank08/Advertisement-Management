using OnlineAdvertisingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdvertisingPortal.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            if(Session["Username"] == null)
            {
                Mydbcontext db = new Mydbcontext();
                return View(from t in db.Categories select t);
            }
            if (Session["Username"].ToString() == "dishank")
            {
                return Redirect("~/Admin/MyCategories");
            }
            else
            {

                Mydbcontext db = new Mydbcontext();
                return View(from t in db.Categories select t);

            }
        }
        
        public ActionResult Business(string name)
        {
            Mydbcontext db = new Mydbcontext();
                var bd = from t in db.BusinessDetails where t.Category == name select t;  
                if (bd != null)
                {
                    return View(bd);
                }
                return HttpNotFound();
        }
    }
}