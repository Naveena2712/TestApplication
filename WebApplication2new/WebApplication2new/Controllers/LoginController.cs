using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2new.Models;

namespace WebApplication2new.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost]


        [ValidateAntiForgeryToken]
        public ActionResult Index(table3 objuser)
        {
            if (ModelState.IsValid)
            {
                using (naviEntities1 db = new naviEntities1())
                {
                    var obj = db.table3.Where(a => a.Email.Equals(objuser.Email) && a.Password.Equals(objuser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Email"] = obj.Email.ToString();
                        Session["Password"] = obj.Password.ToString();
                        Response.Write("Login success");
                        return View("GeneralUser");
                    }
                    else
                    {
                        Response.Write("Login Failed");
                        return View("Admin");

                    }
                }
            }
            return View(objuser);
        }
        public ActionResult GeneralUser()
        {
            return View();
                 
        }
       public ActionResult Admin()
        {
            naviEntities1 nav1 = new naviEntities1();
            return View(nav1.table3.ToList());
        }
    }
}