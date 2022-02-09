using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudOperation.Models;

namespace crudOperation.Controllers
{
    public class StudentsController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        public ActionResult StudentList()
        {
            return View(db.Student.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.title = "Create Student";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Student.Add(student);
            db.SaveChanges();
            ViewBag.title = "Create Student";
            return RedirectToAction("StudentList");
        }

        public ActionResult Edit(int id )
        {
            Student student = db.Student.Find(id);
            ViewBag.title = "Edit Student Information";
            return View("Create", student);

        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }

        public ActionResult Details(int id)
        {
            Student student = db.Student.Find(id);

            ViewBag.title = "Student Details";

            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            Student student = db.Student.Find(id);

            ViewBag.title = "Delete Student";

            return View("Details", student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
            db.SaveChanges();

            return RedirectToAction("StudentList");
        }

        //private UniversityDBContext db = new UniversityDBContext();

        //// GET: Students
        //public ActionResult Index()
        //{
        //    return View(db.Student.ToList());
        //}

        //// GET: Students/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Student.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// GET: Students/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Students/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,RegNo,Email")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Student.Add(student);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);
        //}

        //// GET: Students/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Student.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: Students/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,RegNo,Email")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(student).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(student);
        //}

        //// GET: Students/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Student.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Student student = db.Student.Find(id);
        //    db.Student.Remove(student);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
