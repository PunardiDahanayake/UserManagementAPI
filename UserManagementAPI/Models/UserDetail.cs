using System.ComponentModel.DataAnnotations;
namespace UserManagementAPI.Models
{
    public class UserDetail
    {
        [Key]
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? DateOfBirth { get; set; }
        public int RoleType { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
