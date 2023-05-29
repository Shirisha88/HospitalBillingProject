using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalBillingProj.Models;

namespace HospitalBillingProj.Controllers
{
    public class reportsController : Controller
    {
        private HospitalBillingEntities db = new HospitalBillingEntities();

        // GET: reports
        public ActionResult Index()
        {
            var reports = db.reports.Include(r => r.Bill);
            return View(reports.ToList());
        }

        // GET: reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report report = db.reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: reports/Create
        public ActionResult Create()
        {
            ViewBag.billid = new SelectList(db.Bills, "BillId", "ItemName");
            return View();
        }

        // POST: reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reportid,startDate,endDate,billid")] report report)
        {
            if (ModelState.IsValid)
            {
                db.reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.billid = new SelectList(db.Bills, "BillId", "ItemName", report.billid);
            return View(report);
        }

        // GET: reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report report = db.reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.billid = new SelectList(db.Bills, "BillId", "ItemName", report.billid);
            return View(report);
        }

        // POST: reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reportid,startDate,endDate,billid")] report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.billid = new SelectList(db.Bills, "BillId", "ItemName", report.billid);
            return View(report);
        }

        // GET: reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report report = db.reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            report report = db.reports.Find(id);
            db.reports.Remove(report);
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
