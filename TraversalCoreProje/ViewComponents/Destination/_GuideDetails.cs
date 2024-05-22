using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Destination
{

    public class _GuideDetails : ViewComponent
    {
        private readonly IGuideService _guideService;
        public _GuideDetails(IGuideService guideService)
        {
            _guideService = guideService;
        }
        public IViewComponentResult Invoke()
        {
            int deger = Convert.ToInt16(TempData["GuideId"]);
            var values = _guideService.TGetById(deger);
            return View(values);
        }
    }
}
