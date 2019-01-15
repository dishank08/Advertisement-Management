using OnlineAdvertisingPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdvertisingPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Users()
        {
                Mydbcontext db = new Mydbcontext();
                return View(from t in db.UserDetails select t);
        }

        public ActionResult Delete(string Username)
        {
            if (Session["Username"].ToString() == "dishank")
            {

                Mydbcontext db = new Mydbcontext();
                UserDetails user = db.UserDetails.FirstOrDefault(u => u.Username.Equals(Username));
                db.UserDetails.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Users", "Admin");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult MyCategories()
        {
            if (Session["Username"].ToString() == "dishank")
            {
                Mydbcontext db = new Mydbcontext();
                return View(from t in db.Categories select t);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public ActionResult DeleteCategory(string Cat)
        {
            if (Session["Username"].ToString() == "dishank")
            {

                Mydbcontext db = new Mydbcontext();
                Categories cat = db.Categories.FirstOrDefault(u => u.Categoryname.Equals(Cat));
                db.Categories.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("MyCategories", "Admin");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Categories cat)
        {
            string fileName = Path.GetFileNameWithoutExtension(cat.Imagefile.FileName);
            string extension = Path.GetExtension(cat.Imagefile.FileName);
            fileName += DateTime.Now.ToString("yymmssfff") + extension;
            cat.CategoryPath = "~/Categories/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Categories/"), fileName);
            cat.Imagefile.SaveAs(fileName);
            Mydbcontext db = new Mydbcontext();
            db.Categories.Add(cat);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.Msg = "Category is Successfully added :)";
            return View();
        }

        //[HttpPost]
        //public ActionResult Edit(UserDetails details)
        //{
        //    if (Session["Username"] != null)
        //    {
        //        string name = Session["Username"].ToString();
        //        Mydbcontext db = new Mydbcontext();
        //        UserDetails user = db.UserDetails.FirstOrDefault(u => u.Username.Equals(name));
        //        user.Firstname = details.Firstname;
        //        user.Lastname = details.Lastname;
        //        user.Email = details.Email;
        //        user.Password = details.Password;
        //        user.ConfirmPassword = details.ConfirmPassword;
        //        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Users", "Admin");

        //}
    }
}