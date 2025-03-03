using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WerehouseManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Пользователь loginmodel, string returnURL)
        {
            if (IsUsersValid(loginmodel))
            {
                FormsAuthentication.SetAuthCookie(loginmodel.Логин, false);
                Session["username"] = loginmodel.Логин;
                return Redirect(returnURL);
            }
            else
            {
                //loginmodel.response = "Wrong Username and Password";
                return View("Index", loginmodel);
            }
        }

        private bool IsUsersValid(Пользователь m)
        {
            using (Складской_учетEntities db = new Складской_учетEntities())
            {
                var userret = db.Пользователь.Where(x => x.Логин == m.Логин && x.Пароль == m.Пароль).FirstOrDefault();
                if (userret == null)
                {
                    //m.response = "Wrong Username and Password";
                    //return View("Index", m);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //return (m.username == "admin" && m.password == "admin");
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            //Request.Cookies.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}