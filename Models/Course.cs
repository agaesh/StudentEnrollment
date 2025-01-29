using System;
using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Models
{
    public class Course
    {
        // Unique identifier for the course
        [Key] // Marks this property as the primary key (if using Entity Framework)
        public int CourseId { get; set; }

        // Name of the course
        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot be longer than 100 characters.")]
        public string CourseName { get; set; }

        // A brief description of the course
        [Required(ErrorMessage = "Course description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        // Number of credits for the course
        [Range(1, 6, ErrorMessage = "Credits must be between 1 and 6.")]
        public int Credits { get; set; }

        // Instructor's name
        [Required(ErrorMessage = "Instructor name is required.")]
        [StringLength(100, ErrorMessage = "Instructor name cannot be longer than 100 characters.")]
        public string Instructor { get; set; }

        // Start date of the course
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        // End date of the course
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "End date is required.")]
        [Compare("StartDate", ErrorMessage = "End date must be later than start date.")]
        public DateTime EndDate { get; set; }

        // Department ID - for reference to the department the course belongs to
        [Required(ErrorMessage = "Department ID is required.")]
        public int DepartmentID { get; set; }
    }
}