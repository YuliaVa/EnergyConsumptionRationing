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
    public class StandartExpensesController : Controller
    {
        private EnergyContext db = new EnergyContext();

        // GET: StandartExpenses
        public ActionResult Index(int? page, string SearchOne = "", string SearchTwo = "")
        {
            var query = from i in db.StandartExpense
                        where i.TypesProduction.ProductionName.StartsWith(SearchOne) && i.Quarter.ToString().StartsWith(SearchTwo)
                        select i;
            int PageSize = 10;
            int pageNumber = (page ?? 1);
            var sotorder = query.OrderBy(im => im.ExpenseID);
            return View(sotorder.ToPagedList(pageNumber, PageSize));
        }

        // GET: StandartExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandartExpense standartExpense = db.StandartExpense.Find(id);
            if (standartExpense == null)
            {
                return HttpNotFound();
            }
            return View(standartExpense);
        }

        // GET: StandartExpenses/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName");
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName");
            return View();
        }

        // POST: StandartExpenses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseID,QuarterlyNormEnergyUnit,ProductionID,Year,Quarter,OrganizationID")] StandartExpense standartExpense)
        {
            if (ModelState.IsValid)
            {
                db.StandartExpense.Add(standartExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", standartExpense.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", standartExpense.ProductionID);
            return View(standartExpense);
        }

        // GET: StandartExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandartExpense standartExpense = db.StandartExpense.Find(id);
            if (standartExpense == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", standartExpense.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", standartExpense.ProductionID);
            return View(standartExpense);
        }

        // POST: StandartExpenses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseID,QuarterlyNormEnergyUnit,ProductionID,Year,Quarter,OrganizationID")] StandartExpense standartExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standartExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationID = new SelectList(db.Organization, "OrganizationID", "OrganizationName", standartExpense.OrganizationID);
            ViewBag.ProductionID = new SelectList(db.TypesProduction, "ProductionID", "ProductionName", standartExpense.ProductionID);
            return View(standartExpense);
        }

        // GET: StandartExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandartExpense standartExpense = db.StandartExpense.Find(id);
            if (standartExpense == null)
            {
                return HttpNotFound();
            }
            return View(standartExpense);
        }

        // POST: StandartExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StandartExpense standartExpense = db.StandartExpense.Find(id);
            db.StandartExpense.Remove(standartExpense);
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
