namespace EMS.Core.Common.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException() : base() {}
    
    public NotFoundException(string message, System.Exception innerException) : base(message, innerException){}
    
    public NotFoundException(string name) 
        : base($"Entity ({name}) is not found!") {}
}