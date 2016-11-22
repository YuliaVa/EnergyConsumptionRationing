using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnergyConsumptionRationing.Models;
using PagedList;

namespace EnergyConsumptionRationing.Controllers
{
    public class ConsumedReleasesController : Controller
    {
        private EnergyContext db = new EnergyContext();

        // GET: ConsumedReleases
        public ActionResult Index(int? page, string SearchOne = "", string SearchTwo = "")
        {
            var query = from i in db.ConsumedRelease
                        where i.TypesProduction.ProductionName.StartsWith(SearchOne) && i.Year.ToString().StartsWith(SearchTwo)
                        select i;
            int PageSize = 10;
            int pageNumber = (page ?? 1);
            var sotorder = query.OrderBy(im => im.ConsumptionID);
            return View(sotorder.ToPagedList(pageNumber, PageSize));
        }

        // GET: ConsumedReleases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumedRelease consumedRelease = db.ConsumedRelease.Find(id);
            if (consumedRelease == null)
            {
                return HttpNotFound();
            }
            return View(consumedRelease);
        }

        // GET: ConsumedReleases/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName");
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName");
            return View();
        }

        // POST: ConsumedReleases/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsumptionID,TotalConsumption,Year,Quarter,ProductionID,OrganizationID")] ConsumedRelease consumedRelease)
        {
            if (ModelState.IsValid)
            {
                db.ConsumedRelease.Add(consumedRelease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", consumedRelease.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", consumedRelease.ProductionID);
            return View(consumedRelease);
        }

        // GET: ConsumedReleases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumedRelease consumedRelease = db.ConsumedRelease.Find(id);
            if (consumedRelease == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", consumedRelease.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", consumedRelease.ProductionID);
            return View(consumedRelease);
        }

        // POST: ConsumedReleases/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsumptionID,TotalConsumption,Year,Quarter,ProductionID,OrganizationID")] ConsumedRelease consumedRelease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumedRelease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", consumedRelease.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", consumedRelease.ProductionID);
            return View(consumedRelease);
        }

        // GET: ConsumedReleases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumedRelease consumedRelease = db.ConsumedRelease.Find(id);
            if (consumedRelease == null)
            {
                return HttpNotFound();
            }
            return View(consumedRelease);
        }

        // POST: ConsumedReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsumedRelease consumedRelease = db.ConsumedRelease.Find(id);
            db.ConsumedRelease.Remove(consumedRelease);
            db.SaveChanges();
            return RedirectToAction("Index");
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
