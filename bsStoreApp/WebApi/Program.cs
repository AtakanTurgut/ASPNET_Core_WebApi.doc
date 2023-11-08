using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using WebApi.Extensions;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));   /// Logger

// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;   // Content Negotiation
    config.ReturnHttpNotAcceptable = true;

    config.CacheProfiles.Add("5mins", new CacheProfile() { Duration = 300 });   // 300 sn   -   Caching
})
    .AddXmlDataContractSerializerFormatters()       // Content Negotiation
    .AddCustomCsvFormatter()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)    //
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

//builder.Services.AddScoped<ValidationFilterAttribute>();    // Action Filters  --  IoC

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});  // Validation

builder.Services.AddEndpointsApiExplorer();     // Swagger
//builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger();    // Documenting

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

builder.Services.ConfigureCors();   // Pagination

builder.Services.ConfigureDataShaper();     // Data Shaping

builder.Services.AddCustomMediaTypes();     // Hateoas  -  Root Documentation
builder.Services.AddScoped<IBookLinks, BookLinks>();

builder.Services.ConfigureVersioning();     // Versioning

builder.Services.ConfigureResponseCaching();    // Caching
builder.Services.ConfigureHttpCacheHeaders();

builder.Services.AddMemoryCache();  // Rate Limiting
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddAuthentication();   // Security
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.RegisterRepositories();    // b
builder.Services.RegisterServices();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>(); // Logger
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())    // Swagger  -  Documenting
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "bsStoreApp v1");
        s.SwaggerEndpoint("/swagger/v2/swagger.json", "bsStoreApp v2");
    });
}

if (app.Environment.IsProduction())   //
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();    // Rate Limiting

app.UseCors("CorsPolicy");   // Pagination

app.UseResponseCaching();    // Caching
app.UseHttpCacheHeaders();

app.UseAuthentication();   // Security
app.UseAuthorization();

app.MapControllers();    // Automapper

app.Run();
