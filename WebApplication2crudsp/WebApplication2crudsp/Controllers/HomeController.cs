using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2crudsp.Models;

namespace WebApplication2crudsp.Controllers
{
    public class HomeController : Controller
    {
        naviEntities entities = new naviEntities();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View(entities.procedureselect().ToList());
        }
        [HttpPost]
        public ActionResult Clear()
        {
            ModelState.Clear();
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(tableone t)
        {
           // if(ModelState.IsValid)
           // {
                entities.procedureinsert(t.Name, t.Email, t.Password, t.Age);
                Response.Write("record inserted");
            //}
            /*else
            {
                ModelState.Clear();
            }
            //  
            // return View();*/
            return RedirectToAction("Index");
        }

        
        public ActionResult Edit(int Id)
        {
            var s=entities.procedurefind(Id).FirstOrDefault();
          // return RedirectToAction("Index");
            return View(s);
        }

        [HttpPost]
       public ActionResult Edit(tableone t)
        {
            entities.procedureupdate(t.Id, t.Name, t.Email, t.Password, t.Age);
            return RedirectToAction("Index");
           //  return View(t);
        }

       
        public ActionResult Delete(int Id)
        {
            entities.proceduredelete(Id);
            return RedirectToAction("Index");
        }
    }
}