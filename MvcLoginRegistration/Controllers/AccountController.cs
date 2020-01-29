using MvcLoginRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLoginRegistration.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (LoginDbContext db = new LoginDbContext())
            {
                return View(db.UserAccount.ToList());
            }
        }

        // this method will show blank registraion page after post to server.
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if ( ModelState.IsValid)
            {
                using (LoginDbContext db = new LoginDbContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                // for clear the context of all input controls
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();

        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (LoginDbContext db = new LoginDbContext())
            {
                var usr = db.UserAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }
    }
}