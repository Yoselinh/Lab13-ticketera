using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using Lab13_YoselinCcapera.IInfrastructure.Adapters.Repositories;
using Lab13_YoselinCcapera.IInfrastructure.Adapters.Services;
using Lab13_YoselinCcapera.IInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lab13_YoselinCcapera.Domain.Ports.Service;

namespace Lab13_YoselinCcapera.IInfrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
        });
        
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IExcelReportService, ExcelReportService>();

        return services;
    }
}