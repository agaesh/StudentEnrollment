using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StudentEnrollment.Data;
namespace StudentEnrollment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //InitializeDatabase()
        }

        //private void InitializeDatabase()
        //{
        //    // Create a new scope to get the ApplicationDbContext
        //    using (var context = new ApplicationDbContext())
        //    {
        //        // Call the initializer to ensure the DB is created and seeded
        //        DbInitializer.Initialize(context);
        //    }
        //}
    }
}
