using EventEaseAdmin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Events;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// --- Serilog Logging ---
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithProperty("EnvironmentUserName", Environment.UserName)
    .Enrich.WithProperty("Application", "EventEaseAdmin")
    .WriteTo.Console()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Information()
    .CreateLogger();
builder.Host.UseSerilog();

// --- Add services to the container ---
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
    ));

// ProblemDetails for API clients
builder.Services.AddProblemDetails();

// Health checks
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

// --- Security Headers Middleware ---
app.Use(async (context, next) =>
{
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["X-Frame-Options"] = "DENY";
    context.Response.Headers["Referrer-Policy"] = "no-referrer";
    context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; script-src 'self'; style-src 'self' 'unsafe-inline'; img-src 'self' data:";
    await next();
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// --- Error Handling & Status Code Pages ---
app.UseStatusCodePagesWithReExecute("/Error/StatusCode", "?code={0}");

// --- Health Checks ---
app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync($"{{\"status\":\"{report.Status}\"}}");
    }
});

// --- Logging Middleware ---
app.Use(async (context, next) =>
{
    var sw = Stopwatch.StartNew();
    var requestId = Activity.Current?.Id ?? context.TraceIdentifier;
    Log.Information("Request {Method} {Path} started (RequestId={RequestId})", context.Request.Method, context.Request.Path, requestId);
    try
    {
        await next();
        Log.Information("Request {Method} {Path} finished in {Elapsed}ms (Status={StatusCode}, RequestId={RequestId})", context.Request.Method, context.Request.Path, sw.ElapsedMilliseconds, context.Response.StatusCode, requestId);
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Unhandled exception for {Method} {Path} (RequestId={RequestId})", context.Request.Method, context.Request.Path, requestId);
        throw;
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
