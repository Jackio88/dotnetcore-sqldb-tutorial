using DotNetCoreSqlDb.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddAzureWebAppDiagnostics();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDatabaseContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todos}/{action=Index}/{id?}");
app.Run();
