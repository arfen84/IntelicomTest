using MVC_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var _entities = new CRMEntities();
            var model = _entities.Klienci;
          
            return View(model);
        }

        public ActionResult EditCustomer(int? id)
        {
            return RedirectToAction("Edit", "KlienciEdit", new { id = id });
        }

        public ActionResult CreateCustomer(int? id)
        {
            return RedirectToAction("Create", "KlienciEdit", new { id = id });
        }

        public ActionResult DeleteCustomer(int? id)
        {
            return RedirectToAction("Delete", "KlienciEdit", new { id = id });
        }

        //[HttpPost]
        //public ActionResult EditCustomer(Klienci kl)
        //{
        //    if (true)
        //    {
        //        this.EditCustomer(kl);
        //        return RedirectToAction("Edit","KlienciEdit", kl.Id.ToString());
        //    }
        //    else
        //    {
        //        return PartialView(kl);
        //    }
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}