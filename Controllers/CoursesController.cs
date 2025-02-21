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
using System.Data.Entity.Validation;

namespace StudentEnrollment.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            var viewModel = new CourseManagementViewModel
            {
                Courses = await db.Courses.ToListAsync(),
                CourseHistory = await db.CoursesHistory.ToListAsync()
            };

            return View(viewModel);
        }


        // GET: Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseCode,CourseName,Description,Credits,DepartmentID,isActive")] Course course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(course); // Return view with errors
                }

                // Generate CourseCode correctly
                course.CourseCode = course.GenerateCourseCode(course.DepartmentID, course.CourseName, course.CourseId);

                db.Courses.Add(course);
                await db.SaveChangesAsync(); // Save the Course first so we can use its ID

                // Create a new CourseHistory entry
                var courseHistory = new CourseHistory
                {
                    CourseCode = course.CourseCode,
                    CourseName = course.CourseName,
                    Description = course.Description,
                    IsActive = true,
                    ActionDate = DateTime.Now,
                    UserId = 1 // Replace this with actual user ID if needed
                };

                // Ensure that CourseHistories exists in the DbContext
                db.CoursesHistory.Add(courseHistory);

  
                    await db.SaveChangesAsync();
        
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while saving the course.");
                return View(course);
            }

            return RedirectToAction("Index"); // Ensure a valid return type
        }


        // GET: Courses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseId,CourseName,Description,Credits,Instructor,StartDate,EndDate,DepartmentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Course course = await db.Courses.FindAsync(id);
            //CourseHistory courseHistory =  await db.CoursesHistory.FindAsync(id)

            var courseHistory = new CourseHistory
            {
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                Description = course.Description,
                IsActive = false,
                ActionDate = DateTime.Now,
                UserId = 1 // Replace this with actual user ID if needed
            };

            db.Courses.Remove(course);
            db.CoursesHistory.Add(courseHistory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public string GetCourseCode([Bind(Include = "CourseId,CourseName,Description,Credits,Instructor,StartDate,EndDate,DepartmentID")] Course Course)
        //{
        //    var course = db.Courses.FirstOrDefault(course => C.== courseId);
        //    if (course == null)
        //    {
        //        return "Course not found.";  // Not ideal, lacks status codes.
        //    }

        //    return course.CourseCode;
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<double> CalculateCourseCost(List<int> courseIds)
        {
            // Initialize totalCost variable
            double totalCost = 0;

            // Get course list by filtering out cost column only
            var coursesActionResult = await GetCourses(courseIds);
            if (coursesActionResult is ViewResult viewResult && viewResult.Model is List<Course> courses)
            {
                List<double> listOfCost = courses.Select(e => e.Cost).ToList();

                // Loop and sum up the cost
                foreach (double cost in listOfCost)
                {
                    totalCost += cost;
                }
            }

            // Return total cost
            return totalCost;
        }

        public async Task<ActionResult> GetCourses(List<int> courseIds)
        {
            //Null check on input
            if (courseIds == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Get list of courses which matched courseIds
            List<Course> courses = await db.Courses.Where(c => courseIds.Contains(c.CourseId)).ToListAsync();

            if (courses == null || !courses.Any())
            {
                return HttpNotFound();
            }

            //Return list of courses
            return View(courses);
        }
    }
}
