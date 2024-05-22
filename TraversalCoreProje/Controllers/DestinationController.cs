using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class DestinationController : Controller
    {
		
		private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }

        public IActionResult Index(int p = 1)
        {
            var values = _destinationService.TGetList().ToPagedList(p,6);
            return View(values);
        }

        public async Task<IActionResult> DestinationDetails(int id)
        {
           
            ViewBag.i = id;
            ViewBag.destID = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = value.Id;
            var values = _destinationService.TGetDestinationWithGuide(id);
            TempData["GuideId"] = values.GuideID;
            return View(values);
        }
    }
}
