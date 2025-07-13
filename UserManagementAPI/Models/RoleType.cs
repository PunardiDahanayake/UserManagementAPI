using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RoleType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; } // Primary key, auto-increment
    public string? RoleName { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }   //auto
    public DateTime ModifiedAt { get; set; } //auto
}
