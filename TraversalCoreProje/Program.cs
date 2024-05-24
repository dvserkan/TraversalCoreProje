using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EntityLayer.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Reflection;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices(); //custom scop olu�turma d��ar�dan olu�turdu�um s�n�fdakileri �ekme.

builder.Services.AddDbContext<Context>(); //Context Tan�m
builder.Services.AddIdentity<AppUser, AppRole>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomErrorDescriber>(); //IdentityTan�m & Custom Error & password token g�nderme

builder.Services.AddScoped<GetAllDestinationQueryHandler>(); //CQRS TANIM
builder.Services.AddScoped<CreateDestinationCommandHandler>(); //CQRS TANIM

builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); //MediaTR Kullan�m� 
                                                              //builder.Services.AddMediatR(typeof(Program)); // Di�er bir yol.



builder.Services.AddLocalization(options => options.ResourcesPath = "Resources"); // Opsiyonel, kaynak dosya yolunu belirtir.
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization(); // Di�er hizmetler


// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddLogging(x=>
//{
//	x.ClearProviders();
//	x.SetMinimumLevel(LogLevel.Debug);
//	x.AddDebug();
//}); //Debug Loglama Kayd�n� Tutma.

builder.Services.AddHttpClient(); //Api istekleri kar��la

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Auto Mapper Config.


// Appsettings SqlConnect Okuma Veri taban�na yazma i�in
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.UseSerilog((context, loggerConfiguration) => //Loglama ve Veri taban�na Kay�t Etme
{
    loggerConfiguration
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" });
}); 


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1000); //AUT KALMA ZAMANI
    options.AccessDeniedPath = "/ErrorPage/Error404/";
    options.LoginPath = "/Login/SignIn/";
    options.LogoutPath = "/Login/LogOut/";
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}"); //Hata sayfas� y�nlendirme

var suppertedCultures = new[] { "tr", "fr", "es", "gr", "en", "de" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppertedCultures[1]).AddSupportedCultures(suppertedCultures).AddSupportedUICultures(suppertedCultures);
app.UseRequestLocalization(localizationOptions); //�oklu Dil Deste�i.

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
