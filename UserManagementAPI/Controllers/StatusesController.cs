using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Data;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusesController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ POST: api/Statuses
        [HttpPost]
        public IActionResult CreateStatus([FromBody] Status status)
        {
            status.CreatedAt = DateTime.Now;
            status.ModifiedAt = DateTime.Now;
            _context.Statuses.Add(status);
            _context.SaveChanges();
            return Ok(status);
        }

        // ✅ GET: api/Statuses
        [HttpGet]
        public IActionResult GetAllStatuses()
        {
            var statuses = _context.Statuses.ToList();
            return Ok(statuses);
        }

        // ✅ PUT: api/Statuses/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] Status updatedStatus)
        {
            var status = _context.Statuses.FirstOrDefault(s => s.StatusId == id);
            if (status == null)
                return NotFound("Status not found");

            status.StatusName = updatedStatus.StatusName;
            status.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
            return Ok(status);
        }

        // ✅ DELETE: api/Statuses/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStatus(int id)
        {
            var status = _context.Statuses.FirstOrDefault(s => s.StatusId == id);
            if (status == null)
                return NotFound("Status not found");

            _context.Statuses.Remove(status);
            _context.SaveChanges();
            return Ok("Status deleted successfully");
        }
    }
}
