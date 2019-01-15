using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAdvertisingPortal.Models;
using System.IO;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace OnlineAdvertisingPortal.Controllers
{
    public class AdvertiseController : Controller
    {
        // GET: Advertise
        public ActionResult Details(int id)
        {
            Mydbcontext db = new Mydbcontext();

            BusinessDetails bd = db.BusinessDetails.Find(id);
            if (bd != null)
            {
                ViewBag.Rated = from t in db.Ratings where t.Businessid == id select t;
                return View(bd);
            }
            return HttpNotFound();

        }

        [HttpPost]
        public ActionResult Details(BusinessDetails detail)
        {

            return View();
        }


        public ActionResult AddBusiness()
        {
            Mydbcontext db = new Mydbcontext();
            //List<SelectListItem> Cat= null;
            //var Item = (from s in db.Categories
            //            select new SelectListItem
            //            {
            //                Text = s.Categoryname,
            //                Value = s.Categoryname
            //            }).Distinct();

            //Cat = Item.ToList();
            //ViewBag.MyCategory= Cat; 
            ViewBag.MyCategory = from t in db.Categories select t.Categoryname;
            return View();
        }



        [HttpPost]
        public ActionResult AddBusiness(BusinessDetails details, FormCollection mydetails, string Cat)
        {
            if (Session["Username"] != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(details.Imagefile.FileName);
                string extension = Path.GetExtension(details.Imagefile.FileName);
                fileName += DateTime.Now.ToString("yymmssfff") + extension;
                details.Imagepath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                details.Imagefile.SaveAs(fileName);
                Mydbcontext db = new Mydbcontext();
                BusinessDetails cat = new BusinessDetails()
                {
                    Businessname = Convert.ToString(mydetails["Businessname"]),
                    Ownername = Convert.ToString(mydetails["Ownername"]),
                    //Category = Convert.ToString(mydetails["Category"]),
                    Category = Cat,
                    Description = Convert.ToString(mydetails["Description"]),
                    Address = Convert.ToString(mydetails["Address"]),
                    Mobile = Convert.ToString(mydetails["Mobile"]),
                    Imagepath = details.Imagepath,
                };
                db.BusinessDetails.Add(cat);
                db.SaveChanges();
                ViewBag.MyCategory = from t in db.Categories select t.Categoryname;
                ModelState.Clear();
                ViewBag.Msg = "Your Business is Successfully added :)";
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
