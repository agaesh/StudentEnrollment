using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
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
            [Column(Order = 2)]
            [DisplayName("Code")]
            public String CourseCode { get; set; }
            [Column(Order = 3)]
            [DisplayName("Course Title")]
                public String CourseName { get; set; }

            [Column(Order = 4)]
            public String Description { get; set; }

            // Action: A string describing what action occurred (e.g., "ADD", "DELETE")
            [Required(ErrorMessage = "Action is required.")]
            [StringLength(100, ErrorMessage = "Action cannot be longer than 100 characters.")]
       
            public bool IsActive { get; set; }

            // Optional: Timestamp when the action occurred
            [Required(ErrorMessage = "Action Date is required.")]
            [DisplayName("Action Date")]
            public DateTime ActionDate { get; set; }
            // UserId: The user who performed the action
            [Required(ErrorMessage = "UserId is required.")]
            public int UserId {  get; set; }
        }
    }
//}