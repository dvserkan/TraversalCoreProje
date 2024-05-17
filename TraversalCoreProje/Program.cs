using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices(); //custom scop olu�turma d��ar�dan olu�turdu�um s�n�fdakileri �ekme.

builder.Services.AddDbContext<Context>(); //Context Tan�m
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomErrorDescriber>(); //IdentityTan�m & Custom Error

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddLogging(x=>
//{
//	x.ClearProviders();
//	x.SetMinimumLevel(LogLevel.Debug);
//	x.AddDebug();
//}); //Debug Loglama Kayd�n� Tutma.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Auto Mapper Config.

builder.Services.AddLogging(logging =>
{
	var path = Directory.GetCurrentDirectory();
	logging.ClearProviders();
	logging.SetMinimumLevel(LogLevel.Information);
	logging.AddFile($"{path}\\Logs\\Log1.txt");
});  //loglama ��lemi


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}"); //Hata sayfas� y�nlendirme



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

app.Run();
