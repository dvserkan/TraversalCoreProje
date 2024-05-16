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
		DateTime logdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

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
					_logger.LogInformation($"{p.Name} Kullanıcısı Saat: {logdate} Kayıt İşlemi Yapmıştır."); //Loglama İşlemi.
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
                if (result.Succeeded)
                {
					_logger.LogInformation($"{p.username} Kullanıcısı Saat: {logdate} Giriş İşlemi Yapmıştır."); //Loglama İşlemi.
					return RedirectToAction("Index", "Profile", new { area = "Member" });
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
			_logger.LogInformation($"{user.Name} Kullanıcısı Saat: {logdate} Çıkış İşlemi Yapmıştır."); //Loglama İşlemi.
			await _signInManager.SignOutAsync();
			return RedirectToAction("SignIn", "Login");

        }


    }
}