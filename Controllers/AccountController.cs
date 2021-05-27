using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Auth;
using System.Web.Security;

namespace RepositoryPattern.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        private readonly Models.AppContext db = new Models.AppContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User userModel)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = db.Users.Any(user => user.Email.ToLower() ==
                userModel.Email.ToLower() && user.Password == userModel.Password);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(userModel.Email, false);
                    return RedirectToAction("Create", "Students");
                }
                ModelState.AddModelError("", "Invalid email and password");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                UserRoleMapping urm = new UserRoleMapping();
                urm.UserId = user.Id;
                urm.RoleId = 1;
                db.UserRoleMappings.Add(urm);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}