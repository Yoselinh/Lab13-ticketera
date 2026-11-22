namespace Lab13_YoselinCcapera.Configuration;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        return services;
    }

    
    public static WebApplication UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab13 YoselinCcapera API v1");
        });

        return app;
    }
}