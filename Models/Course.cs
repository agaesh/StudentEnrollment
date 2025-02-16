using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Models
{
    //Unnecessary datatype for two state status ACTIVE, DISABLE
    //public enum StatusEnum
    //{
    //   ACTIVE,
    //   INACTIVE
    //}
    public class Course
    {
        // Unique identifier for the course
        [Key] // Marks this property as the primary key (if using Entity Framework)
        public int CourseId { get; set; }

        [DisplayName("Code")]
        public String CourseCode { get; set; }

        // Name of the course
        [DisplayName("Course Title")]
        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot be longer than 100 characters.")]
        public string CourseName { get; set; }

      

        // A brief description of the course
        [DisplayName("Description")]
        [Required(ErrorMessage = "Course description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [DisplayName("Total Credits")]
        // Number of credits for the course
        [Range(1, 4, ErrorMessage = "Credits must be between 1 and 4.")]
        public int Credits { get; set; }

       /* commented the InstructorCode, StartDate
        // Instructor's name
        //[DisplayName("InstructorCode")]
        //[Required(ErrorMessage = "Instructor name is required.")]
        //[StringLength(100, ErrorMessage = "Instructor name cannot be longer than 100 characters.")]
        //public string InstructorCode{ get; set; }


         Start date of the cours e
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }
       */
        // Department ID - for reference to the department the course belongs to
        [Required(ErrorMessage = "Department ID is required.")]
        [DisplayName("Department ID")]
        public int DepartmentID { get; set; }

        //Enum changed to boolean. easy to handle two status    
        [DisplayName("Status")]
        public bool IsActive { get; set; }

      
            public string GenerateCourseCode(int departmentId, string courseName, int courseId)
            {
                // Convert the DepartmentID to a string (you can format it as needed)
                string departmentIdString = departmentId.ToString().PadLeft(3, '0'); // Example: 001

                // Extract the first 3 letters of the CourseName
                string courseNameShort = courseName.Length >= 3 ? courseName.Substring(0, 3).ToUpper() : courseName.ToUpper();

                // Concatenate to form the CourseCode
                string courseCode = $"{departmentIdString}-{courseNameShort}-{courseId:D4}"; // Example: 001-MAT-0001

                return courseCode;
            }
  


    }
}