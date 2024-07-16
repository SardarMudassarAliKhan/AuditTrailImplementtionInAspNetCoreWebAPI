namespace AuditTrailImplementtionInAspNetCoreWebAPI.Model
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Action { get; set; }
        public string? TableName { get; set; }
        public string? RecordId { get; set; }
        public string? Changes { get; set; }
    }
}
