namespace UserManagementAPI.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string? StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
