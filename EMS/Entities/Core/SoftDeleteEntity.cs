namespace EMS.Entities.Core;

public class SoftDeleteEntity : BaseEntity
{
    public DateTime? DeletedAt { get; set; }
    public string? DeletedByUserName { get; set; }
    public string? DeletedReason { get; set; }
}