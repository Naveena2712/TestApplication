using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace WebApplication3database.Controllers
{
    public class TablenewController : Controller
    {

        naveenaEntities entities = new naveenaEntities();
        // GET: Tablenew
        public ActionResult Index()
        {
            return View(entities.Tablenews.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tablenew tablenew)
        {
            if(ModelState.IsValid)
            {
                entities.Tablenews.Add(tablenew);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablenew);
        }

        public ActionResult Edit(int ID)
        {
            Tablenew tablenew = entities.Tablenews.Find(ID);

            return View(tablenew);
           // return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,NAME,SALARY,DOB,AGE")]Tablenew tablenew)
        {
            if(ModelState.IsValid)
            {
              
                entities.Entry(tablenew).State = EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablenew);
        }
        
        public ActionResult Delete(int ID)
        {

            Tablenew tablenew = entities.Tablenews.Find(ID);
            return View(tablenew);
        }
     
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ID)
        {
            Tablenew tablenew = entities.Tablenews.Find(ID);
            entities.Tablenews.Remove(tablenew);
            entities.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int ID)
        {
            Tablenew tablenew = entities.Tablenews.Find(ID);

            return View(tablenew);
        }
    }
}