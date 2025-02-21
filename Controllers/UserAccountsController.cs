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
    public class UserAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserAccounts
        //This is the most latest 
        public async Task <ActionResult> _Dashboard()
        {
            return View();
        }
        public async Task<ActionResult> Index()
        {
            return View(await db.AccountModel.ToListAsync());
        }

        public async Task<ActionResult> BankingDetail(int? id)
        {
            if (id == null && Session["UserID"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Your logic to fetch banking details goes here...

            return View("ChangeBankDetails");
        }

        // GET: UserAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.AccountModel.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Create
        public ActionResult Create(bool isAdmin)
        {
            //UserAccount model = new UserAccount();
            var model = new UserAccount();

            if (isAdmin)
            {
                // For admin users you might want to allow them to choose a RoleType,
                // but if you want to set a default, you can do so here.
                model.RoleType = "ADMIN"; // Set default value for admin
            }
            else
            {
                // If the user is NOT an admin, force RoleType to Student.
                model.RoleType = "STUDENT";
            }

            //This variable is important to control the UI. 
            //if is Admin. it will shows input that needed create user only and applicable for student also
            ViewBag.isAdmin = isAdmin;

            // If the user is NOT an admin, set RoleType to Student
            //if (!isAdmin)
            //{
            //    model.RoleType = RoleType.Student;
            //}

            return View(model);
        }


        // POST: UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Firstname,ProgramType,ProgramName,FirstName,LastName,ICNumber,Email,Password, RoleType")] UserAccount userAccount)
        {
            try
            {
               db.AccountModel.Add(userAccount);
               await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                // Return the view with errors so the user can correct them
                return View(userAccount);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "RoleType, Email, Password")] LoginViewModel userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }

            try
            {
                var user = await db.AccountModel
                    .FirstOrDefaultAsync(u => u.Email == userAccount.email && u.RoleType == userAccount.roletype);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid email, role, or password.");
                    return View(userAccount);
                }

                // Set session or authentication cookie
                // Set authentication session

                Session["UserId"] = user.ID;
                Session["UserEmail"] = user.Email;
                Session["UserRole"] = user.RoleType;

                return RedirectToAction("_Dashboard", "UserAccounts"); // Redirect after login

            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
                // Log the error (ex)
            }

            return View(userAccount);
        }
        private bool VerifyPassword(string inputPassword, string storedPasswordHash)
        {
            // Implement password hashing verification logic (e.g., BCrypt, SHA256)
            return inputPassword == storedPasswordHash; // Replace with actual hash check
        }

        // GET: UserAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null && Session["UserId"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.AccountModel.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,RoleType,Email,Password,PhoneNumber,Address,ProgramType,ProgramName,FirstName,LastName,ICNumber,Department,AdminPosition,StartDate,isActive,CreatedAt,UpdatedAt")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.AccountModel.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserAccount userAccount = await db.AccountModel.FindAsync(id);
            db.AccountModel.Remove(userAccount);
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
        private async Task<bool> IsValidUserAsync(String roleType, string email, string password)
        {
            // Replace this with your actual authentication logic
            var user = await db.AccountModel
                .FirstOrDefaultAsync(u => u.RoleType == roleType && u.Email == email && u.Password == password);

            return user != null;
        }
    }
}
