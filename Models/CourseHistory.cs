using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    namespace StudentEnrollment.Models
    {
    using System;
    using System.ComponentModel.DataAnnotations;

    namespace StudentEnrollment.Models
    {

        public enum ActionType
        {   Add,
            Delete
        }
        public class CourseHistory
        {
            // Primary Key: Unique identifier for the course history record
            [Key]
            public int Id { get; set; }

            // Foreign Key: ID of the related course
            [Required(ErrorMessage = "CourseId is required.")]
            public int CourseId { get; set; }

            // Action: A string describing what action occurred (e.g., "Course Created", "Course Updated")
            [Required(ErrorMessage = "Action is required.")]
            [StringLength(100, ErrorMessage = "Action cannot be longer than 100 characters.")]
            public ActionType Action { get; set; }

            // Optional: Timestamp when the action occurred
            [Required(ErrorMessage = "Action Date is required.")]
            public DateTime ActionDate { get; set; }

            // Navigation property: This allows us to easily access the related Course data (optional)
            public virtual Course Course { get; set; }

            // UserId: The user who performed the action
            [Required(ErrorMessage = "UserId is required.")]
            public int UserId { get; set; }
        }
    }
}