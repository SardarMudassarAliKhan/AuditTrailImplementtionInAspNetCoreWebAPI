using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AuditTrailImplementtionInAspNetCoreWebAPI.Model
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditLog ToAuditLog()
        {
            var auditLog = new AuditLog
            {
                UserId = UserId,
                Action = Action,
                TableName = TableName,
                Timestamp = DateTime.UtcNow,
                Changes = Newtonsoft.Json.JsonConvert.SerializeObject(NewValues.Count == 0 ? OldValues : NewValues)
            };

            foreach (var keyValue in KeyValues)
            {
                auditLog.RecordId += $"{keyValue.Key}:{keyValue.Value};";
            }

            return auditLog;
        }
    }
}