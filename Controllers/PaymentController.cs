
using StudentEnrollment.Migrations;
using StudentEnrollment.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentEnrollment.Controllers
{
    public class PaymentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Include CoursesController
        public readonly CoursesController _coursesController = new CoursesController();

        //To display all payment details made by the user
        public async Task<ActionResult> GetPaymentDetail(int userId)
        {
            List<Payment> payments = await db.Payments.Where(p => p.UserID == userId).ToListAsync();

            if (payments == null || !payments.Any())
            {
                return HttpNotFound();
            }

            return View(payments);
        }

        //Post
        public async Task<ActionResult> MakePayment(int userId)
        {
            // Get active course histories for the user
            List<int> courseHistoryIds = await db.CoursesHistory
                .Where(u => u.UserId == userId && u.IsActive)
                .Select(u => u.ID)
                .ToListAsync();

            // Check if there are any active course histories
            if (courseHistoryIds == null || !courseHistoryIds.Any())
            {
                return HttpNotFound("No active course histories found for the user.");
            }

            // Call CalculateCourseCost and pass the list of course IDs
            double totalCost = await _coursesController.CalculateCourseCost(courseHistoryIds);

            // Create payment object with the returned result above
            Payment userPayment = new Payment{ UserID = userId, TotalPaymentCost = totalCost };
            await CreatePayment(userPayment);

            // Return the payment details to the view
            ViewBag.TotalCost = totalCost;
            return View();
        }

        public async Task<ActionResult> CreatePayment(Payment payment)
        {
            db.Payments.Add(payment);
            await db.SaveChangesAsync();

            return View();
        }
    }
}