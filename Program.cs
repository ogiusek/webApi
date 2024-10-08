using WebApi.Core.Attributes;

var builder = WebApplication.CreateBuilder(args);

// libraries
// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<StartupBase>());

// application
builder.Services.Addservices();
builder.Services.AddDbContexts(builder.Configuration.GetConnectionString("postgre"));
builder.Services.AddControllers(options =>
{
    options.AddFilters();
});

var app = builder.Build();

app.MapControllers();
app.AddMiddlewares();

app.UseAuthorization();
app.UseRouting();

app.Run();

// jwt
// identity - for external authentication
// xunit for testing

// design patterns for separation of api layer with business logic
// CQRS command query responsibility separation (verified)
// MVC Model view controller (verified)
// HEXAGONAL archtecture (verified)
// SOA Service oriented architecture (not verified)
// CLEAN architecture (not verified)
