using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;

namespace UserManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
