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
    public class DepartmentInformationsController : Controller
    {
        private dbERPEntities db = new dbERPEntities();

        // GET: DepartmentInformations
        public ActionResult Index()
        {
            return View(db.DepartmentInformations.ToList());
        }

        // GET: DepartmentInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentInformation departmentInformation = db.DepartmentInformations.Find(id);
            if (departmentInformation == null)
            {
                return HttpNotFound();
            }
            return View(departmentInformation);
        }

        // GET: DepartmentInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentName,Description")] DepartmentInformation departmentInformation)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentInformations.Add(departmentInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentInformation);
        }

        // GET: DepartmentInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentInformation departmentInformation = db.DepartmentInformations.Find(id);
            if (departmentInformation == null)
            {
                return HttpNotFound();
            }
            return View(departmentInformation);
        }

        // POST: DepartmentInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentName,Description")] DepartmentInformation departmentInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentInformation);
        }

        // GET: DepartmentInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentInformation departmentInformation = db.DepartmentInformations.Find(id);
            if (departmentInformation == null)
            {
                return HttpNotFound();
            }
            return View(departmentInformation);
        }

        // POST: DepartmentInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentInformation departmentInformation = db.DepartmentInformations.Find(id);
            db.DepartmentInformations.Remove(departmentInformation);
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
