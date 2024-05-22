using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginController> _logger;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<LoginController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username

            };
            if (p.ConfirmPassword == p.Password)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    _logger.LogWarning($"{p.Name} Kullanıcısı Saat: {DateTime.Now}  Kayıt İşlemi Yapmıştır."); //Loglama İşlemi.
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (result.Succeeded)
                {
                    // Kullanıcının rolü admin ise admin sayfasına , ziyaretçi ise profil sayfasına gönderilmesi sağlanır.
                    // Kaynak Erhan Gündüz. https://github.com/erhangndz/MyAcademyOneMusic/blob/master/OneMusic.WebUI/Controllers/LoginController.cs
                    var admin = await _userManager.IsInRoleAsync(user, "Admin");
                    var visitor = await _userManager.IsInRoleAsync(user, "Visitor");

                    if (admin == true)
                    {
                        _logger.LogWarning($"{user.Name} {user.Surname} Kullanıcısı Saat: {DateTime.Now} Giriş İşlemi Yapmıştır.");
                        return RedirectToAction("Dashboard", "Admin", new { area = "Admin" });
                        //Admin / Dashboard / Index /
                    }
                    else if (visitor == true)
                    {
                        _logger.LogWarning($"{user.Name} {user.Surname} Kullanıcısı Saat: {DateTime.Now}  Giriş İşlemi Yapmıştır."); //Loglama İşlemi.
                        return RedirectToAction("Dashboard", "Member", new { area = "Member" });
                        //Member / Profile / Index /
                    }

                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            _logger.LogWarning($"{user.Name} {user.Surname} Kullanıcısı Saat: {DateTime.Now} Çıkış İşlemi Yapmıştır."); //Loglama İşlemi.
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login");

        }


    }
}