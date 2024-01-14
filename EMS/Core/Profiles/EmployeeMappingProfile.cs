using AutoMapper;
using EMS.Entities;
using EMS.Core.Contract.Employee.Request;
using EMS.Core.Contract.DTOs;

namespace EMS.Core.Profiles;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, UpdateEmployeeCommand>();
    }
}