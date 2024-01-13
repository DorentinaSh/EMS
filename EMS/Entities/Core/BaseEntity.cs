namespace EMS.Entities.Core;

public class BaseEntity<TPrimaryKey> : AuditEntity
{
    public virtual TPrimaryKey Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<Guid>
{ }