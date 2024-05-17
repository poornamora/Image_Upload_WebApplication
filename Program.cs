using Practice_WebApp_MVC_Venkat_TT.Controllers;
using Practice_WebApp_MVC_Venkat_TT.IRepositories;
using Practice_WebApp_MVC_Venkat_TT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using NLog.Extensions.Logging;
using NLog;
using Multiple_Images_Upload_WebApp.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmployeeRepository,SqlEmployeeRepository>();
builder.Services.AddScoped<SqlEmployeeRepository>();

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Add NLog to the Dependency Injection container
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.ClearProviders();
    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    loggingBuilder.AddNLog();
    loggingBuilder.AddEventSourceLogger();
    loggingBuilder.AddDebug();
});
var app = builder.Build();



LogManager.LoadConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "Textfile.txt"));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    //app.UseStatusCodePagesWithRedirects("/Error/{0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");


app.Run();
