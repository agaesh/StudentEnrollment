using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrollment.Models
{
    //public class Account
    //{
        public enum RoleType
        {
            Admin,
            Student
        }

        public enum ProgramType
        {
            Diploma,
            Degree,
            Master,
            Other
        }
        public enum Program
        {

        }

        public class UserAccount
        {
            [Key]
            public int ID { get; set; }


        [Required(ErrorMessage = "Role is required.")]
        [DisplayName("Role")]
        public String RoleType { get; set; }

            [Required(ErrorMessage ="Email is Required")]
            [EmailAddress]
            [MaxLength(255)]
            public string Email { get; set; }

            
            [Required(ErrorMessage = "Password is Required")]
            [MaxLength(255)]
            public string Password { get; set; }

            [Phone]
            [MaxLength(20)]
            [DisplayName("Phone #")]
            public string PhoneNumber { get; set; }

            [MaxLength(255)]
            public string Address { get; set; }

            public ProgramType ProgramType { get; set; }
            [MaxLength(255)]
            [DisplayName("Program")]
            public string ProgramName { get; set; }

            [Required]
            [MaxLength(255)]
            [DisplayName("First Name")]
            public string FirstName { get; set; }

            [Required]  
            [MaxLength(255)]
            [DisplayName("Last Name")]
            public string LastName { get; set; }

            [Required]
            [MaxLength(20)]
            [DisplayName("IC #")]
            public string ICNumber { get; set; }

            [MaxLength(255)]
            public string Department { get; set; }

            [MaxLength(255)]
            [DisplayName("Position")]
            public string AdminPosition { get; set; }

            [DisplayName("Status")]
        public bool IsActive { get; set; }

        [DisplayName("Create Date")]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            [DisplayName("Update Date")]
            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        }
    }
//}
