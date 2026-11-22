using Lab13_YoselinCcapera;
using Lab13_YoselinCcapera.Application.Services;
using Lab13_YoselinCcapera.Application.UseCases.Clients.Query;
using Lab13_YoselinCcapera.Configuration;
using Lab13_YoselinCcapera.IInfrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(GetAllClientsQuery).Assembly);
});

var app = builder.Build();

//var examples = new ExcelExamples();
//examples.FourthExample();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();