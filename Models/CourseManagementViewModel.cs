using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEnrollment.Models
{
    public class CourseManagementViewModel
    { 
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<CourseHistory> CourseHistory { get; set; }
    }
}