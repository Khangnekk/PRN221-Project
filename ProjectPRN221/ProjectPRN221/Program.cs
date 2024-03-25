using Business_Object.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProjectPRN221Context>(
	opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionStrings")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
var app = builder.Build();
app.UseStaticFiles();
app.MapRazorPages();
app.UseSession();
app.UseRouting();
app.Run();
