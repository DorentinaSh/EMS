using AutoMapper;
using EMS.Core.Profiles;
using EMS.Interfaces;
using EMS.Services;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EmsContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient<IEmployeeService, EmployeeService>();

        services.AddScoped<IEmsContext>(provider => provider.GetRequiredService<EmsContext>());
        services.AddScoped<EmsContextInitializer>();

        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new EmployeeMappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}