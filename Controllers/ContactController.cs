using StudentEnrollment.Models;
using System.Threading.Tasks;
using System;
using System.Web.Mvc;

namespace StudentEnrollment.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,PhoneNumber,Enquirydetail")] Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contact); // Return view with errors
                }

                db.Contacts.Add(contact);
                await db.SaveChangesAsync(); // Save the Course first so we can use its ID
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while saving the course.");
                return View(contact);
            }

            return RedirectToAction("Index"); // Ensure a valid return type
        }
    }
}
