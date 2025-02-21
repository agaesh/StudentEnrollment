using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrollment.Models
{
    public class CourseEnrollment
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [EnumDataType(typeof(EnrollmentStatus))]
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;

        [Required]
        [EnumDataType(typeof(PaymentStatus))]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public DateTime? CompletionDate { get; set; }

        //// Navigation Properties
        [ForeignKey("StudentId")]
        public virtual UserAccount Student { get; set; }

        [ForeignKey("CourseId")]
        public  virtual Course Course{ get; set; }
    }

    public enum EnrollmentStatus
    {
        Active,
        Completed,
        Dropped,
        Pending
    }

    public enum PaymentStatus
    {
        Paid,
        Pending,
        Waived
    }

}
