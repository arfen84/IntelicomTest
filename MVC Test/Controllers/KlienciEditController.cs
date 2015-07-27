using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Models;

namespace MVC_Test.Controllers
{
    public class KlienciEditController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: KlienciEdit
        public ActionResult Index(int id)
        {
            //var _entities = new CRMEntities();
            //var model = _entities.Klienci.Where(m=>m.Id==id);
            return View();
        }

        // GET: KlienciEdit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klienci klienci = db.Klienci.Find(id);
            if (klienci == null)
            {
                return HttpNotFound();
            }
            return View(klienci);
        }

        // GET: KlienciEdit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KlienciEdit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwisko,Imie,Mail,Ulica,Miasto,Kod_pocztowy,TelefonKomorkowy,Friend")] Klienci klienci)
        {
            if (ModelState.IsValid)
            {
                Klienci kl = db.Klienci.OrderByDescending(x => x.Id).First();
                klienci.Id = kl.Id + 1;
                db.Klienci.Add(klienci);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "Home");
            }

            return View(klienci);
        }

        // GET: KlienciEdit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klienci klienci = db.Klienci.Find(id);
            if (klienci == null)
            {
                return HttpNotFound();
            }
            return View(klienci);
        }

        // POST: KlienciEdit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nazwisko,Imie,Mail,Ulica,Miasto,Kod_pocztowy,TelefonKomorkowy,Friend")] Klienci klienci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klienci).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");  Comment mateusz
                return RedirectToAction("Index", "Home");
            }
            return View(klienci);
        }

        // GET: KlienciEdit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klienci klienci = db.Klienci.Find(id);
            if (klienci == null)
            {
                return HttpNotFound();
            }
            return View(klienci);
        }

        // POST: KlienciEdit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klienci klienci = db.Klienci.Find(id);
            db.Klienci.Remove(klienci);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
