using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UserManagementAPI.Models;  // adjust this if your namespace is different
using UserManagementAPI.Data;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;

//Create POST API to Add User (with encryption & email validation)

[Route("api/[controller]")]
[ApiController]
public class UserDetailsController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserDetailsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDetail user)
    {
        // Validate email format
        if (!new EmailAddressAttribute().IsValid(user.Email!))
            return BadRequest("Invalid email address");

        // Check if email already exists
        if (_context.UserDetails.Any(u => u.Email == user.Email))
            return BadRequest("Email already exists");

        // Encrypt password
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        // Set creation dates
        user.CreatedAt = DateTime.Now;
        user.ModifiedAt = DateTime.Now;

        _context.UserDetails.Add(user);
        _context.SaveChanges();

        return Ok(user);


    }

    [Authorize]
    [HttpGet("GetByEmail/{email}")]
    public IActionResult GetUserByEmail(string email)
    {
        var user = (from u in _context.UserDetails
                    join r in _context.RoleTypes on u.RoleType equals r.RoleId
                    join s in _context.Statuses on u.Status equals s.StatusId
                    where u.Email == email              // THIS filters by email
                    select new
                    {
                        userID = u.UserID,
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        email = u.Email,
                        dateOfBirth = u.DateOfBirth,
                        roleName = r.RoleName,
                        statusName = s.StatusName,
                        createdAt = u.CreatedAt,
                        modifiedAt = u.ModifiedAt
                    }).FirstOrDefault(); // Only one result

        if (user == null)
            return NotFound("User not found.");

        return Ok(user);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UserDetail user)
    {
        var existingUser = _context.UserDetails.FirstOrDefault(u => u.UserID == id);
        if (existingUser == null) return NotFound();

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.DateOfBirth = user.DateOfBirth;
        existingUser.RoleType = user.RoleType;
        existingUser.Status = user.Status;
        existingUser.ModifiedAt = DateTime.Now;

        _context.SaveChanges();
        return Ok(existingUser);
    }



    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.UserDetails.FirstOrDefault(u => u.UserID == id);
        if (user == null) return NotFound();

        _context.UserDetails.Remove(user);
        _context.SaveChanges();
        return Ok("User deleted successfully.");
    }


}
