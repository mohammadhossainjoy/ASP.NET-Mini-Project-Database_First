using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HR.Models;

namespace HR.Controllers
{
    public class LeaveEntriesController : Controller
    {
        private dbERPEntities db = new dbERPEntities();

        // GET: LeaveEntries
        public ActionResult Index()
        {
            return View(db.LeaveEntries.ToList());
        }

        // GET: LeaveEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveEntry leaveEntry = db.LeaveEntries.Find(id);
            if (leaveEntry == null)
            {
                return HttpNotFound();
            }
            return View(leaveEntry);
        }

        // GET: LeaveEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,LeaveType,FromDate,ToDate,Reason,Status,AppliedDate")] LeaveEntry leaveEntry)
        {
            if (ModelState.IsValid)
            {
                db.LeaveEntries.Add(leaveEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaveEntry);
        }

        // GET: LeaveEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveEntry leaveEntry = db.LeaveEntries.Find(id);
            if (leaveEntry == null)
            {
                return HttpNotFound();
            }
            return View(leaveEntry);
        }

        // POST: LeaveEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,LeaveType,FromDate,ToDate,Reason,Status,AppliedDate")] LeaveEntry leaveEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveEntry);
        }

        // GET: LeaveEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveEntry leaveEntry = db.LeaveEntries.Find(id);
            if (leaveEntry == null)
            {
                return HttpNotFound();
            }
            return View(leaveEntry);
        }

        // POST: LeaveEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveEntry leaveEntry = db.LeaveEntries.Find(id);
            db.LeaveEntries.Remove(leaveEntry);
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
