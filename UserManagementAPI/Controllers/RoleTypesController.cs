using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Data;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoleTypesController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ POST: api/RoleTypes
        [HttpPost]
        public IActionResult CreateRole([FromBody] RoleType role)
        {
            role.CreatedAt = DateTime.Now;
            role.ModifiedAt = DateTime.Now;
            _context.RoleTypes.Add(role);
            _context.SaveChanges();
            return Ok(role);
        }

        // ✅ GET: api/RoleTypes
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _context.RoleTypes.ToList();
            return Ok(roles);
        }

        // ✅ PUT: api/RoleTypes/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [FromBody] RoleType updatedRole)
        {
            var role = _context.RoleTypes.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
                return NotFound("Role not found");

            role.RoleName = updatedRole.RoleName;
            role.Status = updatedRole.Status;
            role.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
            return Ok(role);
        }

        // ✅ DELETE: api/RoleTypes/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _context.RoleTypes.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
                return NotFound("Role not found");

            _context.RoleTypes.Remove(role);
            _context.SaveChanges();
            return Ok("Role deleted successfully");
        }
    }
}
