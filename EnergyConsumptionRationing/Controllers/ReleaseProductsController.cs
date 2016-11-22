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
    public class ReleaseProductsController : Controller
    {
        private EnergyContext db = new EnergyContext();

        // GET: ReleaseProducts
        public ActionResult Index(int? page, string SearchOne = "", string SearchTwo  = "")
        {
            var query = from i in db.ReleaseProducts
                        where i.TypesProduction.ProductionName.StartsWith(SearchOne) && i.Organization.OrganizationName.StartsWith(SearchTwo)
                        select i;
            int PageSize = 10;
            int pageNumber = (page ?? 1);
            var sotorder = query.OrderBy(im => im.ReleaseID);
            return View(sotorder.ToPagedList(pageNumber, PageSize));
        }

        // GET: ReleaseProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleaseProducts releaseProducts = db.ReleaseProducts.Find(id);
            if (releaseProducts == null)
            {
                return HttpNotFound();
            }
            return View(releaseProducts);
        }

        // GET: ReleaseProducts/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName");
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName");
            return View();
        }

        // POST: ReleaseProducts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReleaseID,ProductionID,TotalRelease,Year,Quarter,OrganizationID")] ReleaseProducts releaseProducts)
        {
            if (ModelState.IsValid)
            {
                db.ReleaseProducts.Add(releaseProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", releaseProducts.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", releaseProducts.ProductionID);
            return View(releaseProducts);
        }

        // GET: ReleaseProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleaseProducts releaseProducts = db.ReleaseProducts.Find(id);
            if (releaseProducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", releaseProducts.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", releaseProducts.ProductionID);
            return View(releaseProducts);
        }

        // POST: ReleaseProducts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReleaseID,ProductionID,TotalRelease,Year,Quarter,OrganizationID")] ReleaseProducts releaseProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(releaseProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", releaseProducts.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", releaseProducts.ProductionID);
            return View(releaseProducts);
        }

        // GET: ReleaseProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleaseProducts releaseProducts = db.ReleaseProducts.Find(id);
            if (releaseProducts == null)
            {
                return HttpNotFound();
            }
            return View(releaseProducts);
        }

        // POST: ReleaseProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReleaseProducts releaseProducts = db.ReleaseProducts.Find(id);
            db.ReleaseProducts.Remove(releaseProducts);
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
