using OnlineAdvertisingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdvertisingPortal.Controllers
{
    public class RatingsController : Controller
    {

        // GET: Ratings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetRatings(int id,double rate)
        {
            Mydbcontext db = new Mydbcontext();
            Ratings r = new Ratings();
            r.Rate = rate;
            r.Businessid = id;
            r.Username = Session["Username"].ToString();
            db.Ratings.Add(r);
            db.SaveChanges();
            int i = 0;
            double ratings = 0;
            var bd = from t in db.Ratings where t.Businessid == id select t;
            foreach (var t in bd)
            {
                ratings += t.Rate;
                i++;
            }
            ratings /= i;
            ratings = Math.Truncate(ratings * 100) / 100;
            var details = new BusinessDetails()
            {
                Id = id,
                Overall = ratings
            };
            db.BusinessDetails.Attach(details);
            db.Entry(details).Property(x => x.Overall).IsModified = true;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();

            return RedirectToAction("Details", "Advertise", new { id = id});
        }
    }
}