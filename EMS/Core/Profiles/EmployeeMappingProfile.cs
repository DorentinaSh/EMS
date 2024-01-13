using AutoMapper;
using EMS.Entities;
using EMS.Core.Contract.Employee.Request;

namespace EMS.Core.Profiles;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
    }
}