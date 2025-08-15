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
    public class AttendanceEntriesController : Controller
    {
        private dbERPEntities db = new dbERPEntities();

        // GET: AttendanceEntries
        public ActionResult Index()
        {
            return View(db.AttendanceEntries.ToList());
        }

        // GET: AttendanceEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceEntry attendanceEntry = db.AttendanceEntries.Find(id);
            if (attendanceEntry == null)
            {
                return HttpNotFound();
            }
            return View(attendanceEntry);
        }

        // GET: AttendanceEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttendanceEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,AttendanceDate,EntryTime,ExitTime,Status,Remarks")] AttendanceEntry attendanceEntry)
        {
            if (ModelState.IsValid)
            {
                db.AttendanceEntries.Add(attendanceEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendanceEntry);
        }

        // GET: AttendanceEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceEntry attendanceEntry = db.AttendanceEntries.Find(id);
            if (attendanceEntry == null)
            {
                return HttpNotFound();
            }
            return View(attendanceEntry);
        }

        // POST: AttendanceEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,AttendanceDate,EntryTime,ExitTime,Status,Remarks")] AttendanceEntry attendanceEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendanceEntry);
        }

        // GET: AttendanceEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceEntry attendanceEntry = db.AttendanceEntries.Find(id);
            if (attendanceEntry == null)
            {
                return HttpNotFound();
            }
            return View(attendanceEntry);
        }

        // POST: AttendanceEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendanceEntry attendanceEntry = db.AttendanceEntries.Find(id);
            db.AttendanceEntries.Remove(attendanceEntry);
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
