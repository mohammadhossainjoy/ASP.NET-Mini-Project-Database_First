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
    public class employeeInformationsController : Controller
    {
        private dbERPEntities db = new dbERPEntities();

        // GET: employeeInformations
        public ActionResult Index()
        {
            return View(db.employeeInformations.ToList());
        }

        // GET: employeeInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeInformation employeeInformation = db.employeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // GET: employeeInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,JobTitle,Department,DateOfBirth,Email,Phone,Address,JoinDate,Id")] employeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                db.employeeInformations.Add(employeeInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeInformation);
        }

        // GET: employeeInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeInformation employeeInformation = db.employeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // POST: employeeInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,JobTitle,Department,DateOfBirth,Email,Phone,Address,JoinDate,Id")] employeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeInformation);
        }

        // GET: employeeInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeInformation employeeInformation = db.employeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // POST: employeeInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeInformation employeeInformation = db.employeeInformations.Find(id);
            db.employeeInformations.Remove(employeeInformation);
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
