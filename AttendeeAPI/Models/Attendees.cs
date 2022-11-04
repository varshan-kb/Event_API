using System;
using System.ComponentModel.DataAnnotations;

namespace AttendeeAPI.Models
{
    public class Attendees
    {
        [Key]
        public int AttendeeID { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public int InvitationID { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
