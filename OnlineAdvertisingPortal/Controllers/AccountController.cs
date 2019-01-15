using OnlineAdvertisingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdvertisingPortal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (Mydbcontext db = new Mydbcontext())
            {
                return View(db.UserDetails.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDetails account)
        {
            if(ModelState.IsValid)
            {
                using (Mydbcontext db = new Mydbcontext())
                {
                    if (db.UserDetails.Where(u => u.Username == account.Username).FirstOrDefault()!=null)
                    {
                        ViewBag.error = "Username already exist";
                        return View();
                    }
                    db.UserDetails.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Firstname + " " + account.Lastname + " successfully registered.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetails user)
        {
            if (user.Username == "dishank" && user.Password == "hello@123")
            {
                Session["Username"] = user.Username.ToString();
                return RedirectToAction("Users", "Admin");
            }
            else
            {
                using (Mydbcontext db = new Mydbcontext())
                {
                    var usr = db.UserDetails.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                    if (usr != null)
                    {
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "Username or Password is Invalid!";
                    }
                }
                return View();
            }
            
        }

        public ActionResult LoggedOut()
        {
            if(Session["Username"] != null)
            {
                Session.Abandon();
            }
            return RedirectToAction("Login");
        }


        public ActionResult Edit()
        {
            string name = Session["Username"].ToString();
            Mydbcontext db = new Mydbcontext();
            UserDetails user = db.UserDetails.FirstOrDefault(u => u.Username.Equals(name));
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserDetails details)
        {
            if (Session["Username"] != null)
            {
                string name = Session["Username"].ToString();
                Mydbcontext db = new Mydbcontext();
                UserDetails user = db.UserDetails.FirstOrDefault(u => u.Username.Equals(name));
                user.Firstname = details.Firstname;
                user.Lastname = details.Lastname;
                user.Email = details.Email;
                user.Password = details.Password;
                user.ConfirmPassword = details.ConfirmPassword;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");

        }

    }
}