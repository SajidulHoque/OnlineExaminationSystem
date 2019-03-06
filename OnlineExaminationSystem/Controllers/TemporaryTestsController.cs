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
    public class TemporaryTestsController : Controller
    {
        private OESDatabaseEntities db = new OESDatabaseEntities();

        // GET: TemporaryTests
        public ActionResult Index()
        {
            var temporaryTests = db.TemporaryTests.Include(t => t.Exam).Include(t => t.Student);
            return View(temporaryTests.ToList());
        }

        // GET: TemporaryTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryTest temporaryTest = db.TemporaryTests.Find(id);
            if (temporaryTest == null)
            {
                return HttpNotFound();
            }
            return View(temporaryTest);
        }

        // GET: TemporaryTests/Create
        public ActionResult Create()
        {
            ViewBag.ExamId = new SelectList(db.Exams, "ExamId", "Attendents");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: TemporaryTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,StudentId,ExamId,TotalRightAnswer,TotalWrongAnswer,ObtainedMark,Answer,isCorrect")] TemporaryTest temporaryTest)
        {
            if (ModelState.IsValid)
            {
                db.TemporaryTests.Add(temporaryTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamId = new SelectList(db.Exams, "ExamId", "Attendents", temporaryTest.ExamId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", temporaryTest.StudentId);
            return View(temporaryTest);
        }

        // GET: TemporaryTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryTest temporaryTest = db.TemporaryTests.Find(id);
            if (temporaryTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamId = new SelectList(db.Exams, "ExamId", "Attendents", temporaryTest.ExamId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", temporaryTest.StudentId);
            return View(temporaryTest);
        }

        // POST: TemporaryTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,StudentId,ExamId,TotalRightAnswer,TotalWrongAnswer,ObtainedMark,Answer,isCorrect")] TemporaryTest temporaryTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporaryTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamId = new SelectList(db.Exams, "ExamId", "Attendents", temporaryTest.ExamId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", temporaryTest.StudentId);
            return View(temporaryTest);
        }

        // GET: TemporaryTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryTest temporaryTest = db.TemporaryTests.Find(id);
            if (temporaryTest == null)
            {
                return HttpNotFound();
            }
            return View(temporaryTest);
        }

        // POST: TemporaryTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemporaryTest temporaryTest = db.TemporaryTests.Find(id);
            db.TemporaryTests.Remove(temporaryTest);
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
