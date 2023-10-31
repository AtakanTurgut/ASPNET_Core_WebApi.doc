using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services.Contracts;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));   /// Logger

// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;   // Content Negotiation
    config.ReturnHttpNotAcceptable = true;
})
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters()       // Content Negotiation
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)    //
    .AddNewtonsoftJson();

//builder.Services.AddScoped<ValidationFilterAttribute>();    // Action Filters  --  IoC


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});  // Validation

builder.Services.AddEndpointsApiExplorer();     // Swagger
builder.Services.AddSwaggerGen();

// DBContext  - Register //
/*
builder.Services.AddDbContext<RepositoryContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))
    );
*/

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.ConfigureLoggerService();   // Logger

builder.Services.AddAutoMapper(typeof(Program));    // Automapper

builder.Services.ConfigureActionFilters();   // Action Filters 

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>(); // Logger
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())   //
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();    // Automapper

app.Run();
