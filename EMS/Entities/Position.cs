using EMS.Entities.Core;

namespace EMS.Entities;

public class Position : SoftDeleteEntity
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    
    public Position(){}

    public Position(string name, string? code)
    {
        Name = name;
        Code = code;
    }
}