using System;
using System.ComponentModel;

namespace StudentEnrollment.Models
{
    public class Contact
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }

        [DisplayName("Enquiry Detail")]
        public string EnquiryDetail { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}