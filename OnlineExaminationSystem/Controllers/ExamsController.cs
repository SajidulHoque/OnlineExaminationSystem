using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExaminationSystem.Models;

namespace OnlineExaminationSystem.Controllers
{
    public class ExamsController : Controller
    {
        private OESDatabaseEntities db = new OESDatabaseEntities();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Course).Include(e => e.Question).Include(e => e.Teacher);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionName");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamId,CourseID,TeacherId,QuestionId,Attendents,TotalMarks,ExamDate,isOnline,isCatagorized,Categories,NoOfQuestion")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", exam.CourseID);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionName", exam.QuestionId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", exam.TeacherId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", exam.CourseID);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionName", exam.QuestionId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", exam.TeacherId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamId,CourseID,TeacherId,QuestionId,Attendents,TotalMarks,ExamDate,isOnline,isCatagorized,Categories,NoOfQuestion")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseId", "CourseName", exam.CourseID);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionName", exam.QuestionId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", exam.TeacherId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
