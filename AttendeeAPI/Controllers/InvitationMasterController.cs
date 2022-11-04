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
    public class InvitationMasterController : ControllerBase
    {
        public readonly _DBContext db;
        public InvitationMasterController(_DBContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Route("GetInvitation")]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.InvitationMaster.OrderByDescending(x => x.InvitationID).ToListAsync());
        }
        [HttpGet]
        [Route("GetInvitationByID/{Id}")]
        public async Task<IActionResult> GetInvitationById(int InvitationID)
        {
            return Ok(await db.InvitationMaster.FindAsync(InvitationID));
        }
        [HttpPost]
        [Route("AddInvitation")]
        public async Task<IActionResult> Post(InvitationMaster invitation)
        {
            var result = await db.InvitationMaster.AddAsync(invitation);
            await db.SaveChangesAsync();
            if (result.Entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok();
        }
        [HttpPut]
        [Route("UpdateInvitation")]
        public async Task<IActionResult> Put(InvitationMaster invitation)
        {
            db.Entry(invitation).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteInvitation")]
        public async Task<IActionResult> Delete(int InvitationID)
        {
            var Invitation = db.InvitationMaster.Find(InvitationID);
            db.Entry(Invitation).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
