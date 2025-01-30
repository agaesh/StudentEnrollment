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

        //// End date of the course
        //[DataType(DataType.Date)]
        //[Required(ErrorMessage = "End date is required.")]
        ////[Compare("StartDate", ErrorMessage = "End date must be later than start date.")]
        //public DateTime EndDate { get; set; }
       */
        // Department ID - for reference to the department the course belongs to
        [Required(ErrorMessage = "Department ID is required.")]
        public int DepartmentID { get; set; }

        //Enum changed to boolean. easy to handle two status    
        public bool IsActive { get; set; }
    }
}