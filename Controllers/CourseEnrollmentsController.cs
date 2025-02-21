using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentEnrollment.Models;

namespace StudentEnrollment.Controllers
{
    public class CourseEnrollmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseEnrollments
        public async Task<ActionResult> Index()
        {
            return View(await db.CourseEnrollments.ToListAsync());
        }

        // GET: CourseEnrollments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnrollment courseEnrollment = await db.CourseEnrollments.FindAsync(id);
            if (courseEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudentId,CourseId,EnrollmentDate,Status,PaymentStatus,CompletionDate")] CourseEnrollment courseEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.CourseEnrollments.Add(courseEnrollment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnrollment courseEnrollment = await db.CourseEnrollments.FindAsync(id);
            if (courseEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudentId,CourseId,EnrollmentDate,Status,PaymentStatus,CompletionDate")] CourseEnrollment courseEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseEnrollment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnrollment courseEnrollment = await db.CourseEnrollments.FindAsync(id);
            if (courseEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CourseEnrollment courseEnrollment = await db.CourseEnrollments.FindAsync(id);
            db.CourseEnrollments.Remove(courseEnrollment);
            await db.SaveChangesAsync();
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
