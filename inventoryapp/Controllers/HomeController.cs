using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inventoryapp.Models;

namespace inventoryapp.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        thinkbridgeEntities dbobj = new thinkbridgeEntities();
        public ActionResult Index()
        {
            return View(dbobj.Inventories.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AfterAdd(Inventory item)
        {
            dbobj.Inventories.Add(item);
            dbobj.SaveChanges();
            return Redirect("/Home/Index");
        }

        public ActionResult Delete(int id)
        {
            Inventory itemToBeDeleted = dbobj.Inventories.Find(id);
            dbobj.Inventories.Remove(itemToBeDeleted);
            dbobj.SaveChanges();
            return Redirect("/Home/Index");
        }

        public ActionResult Update(int id)
        {
            Inventory item = dbobj.Inventories.Find(id);
            return View(item);
        }
        public ActionResult AfterUpdate  (Inventory item)
        {
            Inventory ItemToBeUpdated = dbobj.Inventories.Find(item.product_id);
            ItemToBeUpdated.name = item.name;
            ItemToBeUpdated.description = item.description;
            ItemToBeUpdated.unit_price = item.unit_price;
            ItemToBeUpdated.qty = item.qty;

            dbobj.SaveChanges();
            return Redirect("/Home/Index");
        }

    }
}