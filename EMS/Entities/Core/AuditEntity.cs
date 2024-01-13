namespace EMS.Entities.Core;

public class AuditEntity
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedByUserName { get; set; }

    public DateTime UpdatedAt { get; set; }
    public string? UpdatedByUserName { get; set; }
}