using API.Exceptions.Base;
using API.Filters;
using API.Middlewares;
using IoC.Configurations;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration.Context;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.AddSentryConfiguration();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddMvcCore(c =>
{
    c.Filters.Add<ExceptionFilter>();
    c.Filters.Add<TransactionFilter>();
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling =
        Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.AddRouting(c => c.LowercaseUrls = true);

builder.Services.AddScoped<ApiAuthorizationMiddleware>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "firebase.Local.json");

app.UseInfrastructure(builder.Configuration);
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseMiddleware<ApiAuthorizationMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.UseSentryTracing();

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var database = scope.ServiceProvider.GetService<ApplicationDbContext>();
    if (database == null)
    {
        throw new ApiException("api-cant-execute-migrate-and-seeders");
    }

    database.Database.Migrate();
}

app.Run();