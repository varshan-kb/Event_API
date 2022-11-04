using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AttendeeAPI.DBContext;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AttendeeAPI.Models;

namespace AttendeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        public readonly _DBContext db;
        public AttendeesController(_DBContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Route("GetAttendees")]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.Attendees.OrderByDescending(x => x.AttendeeID).ToListAsync());
        }
        [HttpGet]
        [Route("GetAttendeesByID/{Id}")]
        public async Task<IActionResult> GetAttendeesById(int AttendeeID)
        {
            return Ok(await db.Attendees.FindAsync(AttendeeID));
        }
        [HttpGet]
        [Route("GetAttendeesByInvitationID/{Id}")]
        public async Task<IActionResult> GetAttendeesByInvitationID(int ID)
        {
            var result = await db.Attendees.Where(x => x.InvitationID == ID).Select(x => new Attendees
            {
                AttendeeID = x.AttendeeID,
                Name = x.Name,
                Email = x.Email,
                Status = x.Status,
                InvitationID = x.InvitationID

            }).ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        [Route("AddAttendees")]
        public async Task<IActionResult> Post(Attendees attendees)
        {
            var result = await db.Attendees.AddAsync(attendees);
            await db.SaveChangesAsync();
            if (result.Entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok(true);
        }
        [HttpPut]
        [Route("UpdateAttendees")]
        public async Task<IActionResult> Put(Attendees attendees)
        {
            db.Entry(attendees).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("Deleteattendees")]
        public async Task<IActionResult> Delete(int AttendeeID)
        {
            var Attendee = db.Attendees.Find(AttendeeID);
            db.Entry(Attendee).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
