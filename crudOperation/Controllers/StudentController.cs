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
    public class StudentController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        private SelectList StudentDepartments()
        {
            SelectList allDepartments = new SelectList(db.Department, "Id", "Name");
            return allDepartments;
        } 

        public ActionResult StudentList()
        {
            ViewBag.title = "Student List";
            return View(db.Student.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.allDepartments = StudentDepartments();
            ViewBag.title = "Create Student";
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(StudentModels student)
        {
            ViewBag.allDepartments = StudentDepartments();
            if (ModelState.IsValid)
            {
                DepartmentModels department = db.Department.Find(student.DepartmentId);
                if (department != null)
                {
                    db.Student.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("StudentList");
                }
                ModelState.AddModelError(nameof(StudentModels.DepartmentId), "Please select department");

            }
            
            ViewBag.title = "Create Student";
            return View(student);
        }

        public ActionResult Edit(int? id )
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels student = db.Student.Find(id);
            ViewBag.allDepartments = StudentDepartments();
            ViewBag.title = "Edit Student Information";
            return View("Create", student);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModels student)
        {
            ViewBag.allDepartments = StudentDepartments();
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("StudentList");
            }
            
            return View(student);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels student = db.Student.Find(id);
            if(student == null)
            {
                return HttpNotFound();
            }

            ViewBag.title = "Student Details";

            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.title = "Delete Student";

            return View("Details", student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels student = db.Student.Find(id);
            if (student != null)
            {
                db.Student.Remove(student);
                db.SaveChanges();
            }
            
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
