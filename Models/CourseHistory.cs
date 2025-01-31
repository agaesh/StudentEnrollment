using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



//namespace StudentEnrollment.Models
//{
//using System;
//using System.ComponentModel.DataAnnotations;

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
            [Column(Order =1 )]
            public int ID { get; set; }

            // Foreign Key: ID of the related course
            [Required(ErrorMessage = "CourseId is required.")]

        //Commented the courseId below. Because it is so unnecessary.
        //public int CourseId { get; set; }
            [Column(Order = 2)]
    
            public String CourseCode { get; set; }
            [Column(Order = 3)]
                public String CourseName { get; set; }
            [Column(Order = 4)]
            public String Description { get; set; }

            // Action: A string describing what action occurred (e.g., "ADD", "DELETE")
            [Required(ErrorMessage = "Action is required.")]
            [StringLength(100, ErrorMessage = "Action cannot be longer than 100 characters.")]
            //Comented the code below as no longer use this one
            //public ActionType Action { get; set; }
            public String Action { get; set; }

            // Optional: Timestamp when the action occurred
            [Required(ErrorMessage = "Action Date is required.")]
            public DateTime ActionDate { get; set; }

            // Navigation property: This allows us to easily access the related Course data (optional)
            //Removed the navigation property. so it wont create foreign key constraint with course model autoamatically
            //public virtual Course Course { get; set; } 

            // UserId: The user who performed the action
            [Required(ErrorMessage = "UserId is required.")]
            public int UserId {  get; set; }
        }
    }
//}