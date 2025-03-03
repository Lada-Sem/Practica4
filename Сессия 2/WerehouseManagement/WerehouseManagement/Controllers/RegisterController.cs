using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WerehouseManagement.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Пользователь model)
        {
            using (Складской_учетEntities db = new Складской_учетEntities())
            {
                //var userret = db.users.Where(x => x.username == model.username && x.password == model.password).FirstOrDefault();
                db.Пользователь.Add(model);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.Логин, false);
                Session["username"] = model.Логин;
                return Redirect("/home/index");
            }
            return View();
        }
    }
}