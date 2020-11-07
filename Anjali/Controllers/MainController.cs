using Anjali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anjali.Controllers
{
    public class MainController : Controller
    {
        public ViewResult Home()
        {
            var context = new LntDatabaseEntitiesEntities1();
            var model = context.orders.ToList();
            return View(model);
        }
        public ViewResult Login()
        {
            var context = new LntDatabaseEntitiesEntities1();
            var model = context.orders.ToList();
            return View(model);
        }
        public ViewResult showorder()
        {
            var context = new LntDatabaseEntitiesEntities1();
            var model = context.orders.ToList();
            return View(model);
        }
        public ViewResult Find(string id)
        {
            int custid = int.Parse(id);
            var context = new LntDatabaseEntitiesEntities1();
            var model = context.orders.FirstOrDefault((e) => e.cust_id == custid);
            return View(model);

        }
        [HttpPost]
        public ActionResult Find(orders ord)
        {
            var context = new LntDatabaseEntitiesEntities1();
            var model = context.orders.FirstOrDefault((e) => e.cust_id == ord.cust_id);
            model.cust_name = ord.cust_name;
            model.item_name = ord.item_name;
            model.price = ord.price;
            context.SaveChanges();//Commits the changes made to the records...
            return RedirectToAction("showorder");
        }

        public ViewResult Neworders()
        {
            var model = new orders();//No Values in it...
            return View(model);
        }
        [HttpPost]
        public ActionResult Neworders(orders ord)
        {
            var context = new LntDatabaseEntitiesEntities1();
            context.orders.Add(ord);
            context.SaveChanges();
            return RedirectToAction("showorder");
        }

        public ActionResult Delete(string id)
        {
            //convert string to int
            int custid = int.Parse(id);
            var context = new LntDatabaseEntitiesEntities1();
            var model = context.orders.FirstOrDefault((e) => e.cust_id == custid);
            context.orders.Remove(model);
            context.SaveChanges();
            return RedirectToAction("showorder");
        }

    }
}