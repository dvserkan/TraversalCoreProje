using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        private readonly Context _context;

        public DashboardController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult LogList(int p = 1)
        {
            var values = _context.Logs.Where(x=> x.Level== "Warning").OrderByDescending(x=> x.TimeStamp).ToList().ToPagedList(p,10);
            return View(values);
        }

	}
}
