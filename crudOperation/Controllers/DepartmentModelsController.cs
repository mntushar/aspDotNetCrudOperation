using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudOperation.Models;
using crudOperation.Models.ModelsContext;

namespace crudOperation.Controllers
{
    public class DepartmentController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.Department.ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModels Department = db.Department.Find(id);
            if (Department == null)
            {
                return HttpNotFound();
            }
            return View(Department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code")] DepartmentModels Department)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(Department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModels departmentModels = db.Department.Find(id);
            if (departmentModels == null)
            {
                return HttpNotFound();
            }
            return View(departmentModels);
        }

        // POST: DepartmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code")] DepartmentModels department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: DepartmentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModels departmentModels = db.Department.Find(id);
            if (departmentModels == null)
            {
                return HttpNotFound();
            }
            return View(departmentModels);
        }

        // POST: DepartmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentModels departmentModels = db.Department.Find(id);
            db.Department.Remove(departmentModels);
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
