using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace StudentEnrollment.Models
{
    public class AccountViewModelStep1
    {
        [Required(ErrorMessage = "IC Number is required.")]
        [MaxLength(20)]
        [DisplayName("IC Number")]
        public string ICNumber { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Program Type is required.")]
        public ProgramType ProgramType { get; set; }

        [MaxLength(255)]
        [DisplayName("Program Name")]
        public string ProgramName { get; set; }
    }
}