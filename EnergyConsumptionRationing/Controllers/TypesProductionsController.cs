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
    public class TypesProductionsController : Controller
    {
        private EnergyContext db = new EnergyContext();

        // GET: TypesProductions
        public ActionResult Index(int? page, string Search = "")
        {
            var query = from tp in db.TypesProduction
                        where tp.ProductionName.StartsWith(Search)
                        select tp;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var sotrorder = query.OrderBy(t => t.ProductionID);
            return View(sotrorder.ToPagedList(pageNumber, pageSize));
        }

        // GET: TypesProductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesProduction typesProduction = db.TypesProduction.Find(id);
            if (typesProduction == null)
            {
                return HttpNotFound();
            }
            return View(typesProduction);
        }

        // GET: TypesProductions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypesProductions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionID,ProductionName,MeasureUnit")] TypesProduction typesProduction)
        {
            if (ModelState.IsValid)
            {
                db.TypesProduction.Add(typesProduction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typesProduction);
        }

        // GET: TypesProductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesProduction typesProduction = db.TypesProduction.Find(id);
            if (typesProduction == null)
            {
                return HttpNotFound();
            }
            return View(typesProduction);
        }

        // POST: TypesProductions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionID,ProductionName,MeasureUnit")] TypesProduction typesProduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typesProduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typesProduction);
        }

        // GET: TypesProductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypesProduction typesProduction = db.TypesProduction.Find(id);
            if (typesProduction == null)
            {
                return HttpNotFound();
            }
            return View(typesProduction);
        }

        // POST: TypesProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypesProduction typesProduction = db.TypesProduction.Find(id);
            db.TypesProduction.Remove(typesProduction);
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
