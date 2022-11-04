using AttendeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendeeAPI.DBContext
{
    public class _DBContext : DbContext
    {
        public _DBContext(DbContextOptions<_DBContext> options) : base(options)
        {
        }
        public DbSet<Attendees> Attendees { get; set; } = null!;
        public DbSet<InvitationMaster> InvitationMaster { get; set; } = null!;
    }
}
