using Microsoft.EntityFrameworkCore;
using WebtechnologiesLabs.Data;
using WebtechnologiesLabs.Models;

// store DateTime without converting it to UTC
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DriveTrackContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DriveTrackContext")));

var app = builder.Build();

// fill the database with test data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// In development, always send the current css/js. MapStaticAssets keeps the ETag from build time,
// so under dotnet watch the browser gets 304 and keeps the old file even after a reload.
if (app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        context.Request.Headers.Remove("If-None-Match");
        context.Request.Headers.Remove("If-Modified-Since");

        context.Response.OnStarting(() =>
        {
            context.Response.Headers.CacheControl = "no-store";
            return Task.CompletedTask;
        });

        await next(context);
    });
}

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();