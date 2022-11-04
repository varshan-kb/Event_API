using System;
using System.ComponentModel.DataAnnotations;

namespace AttendeeAPI.Models
{
    public class InvitationMaster
    {
        [Key]
        public int InvitationID { get; set; }
        [StringLength(250)]
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
       
    }
}
