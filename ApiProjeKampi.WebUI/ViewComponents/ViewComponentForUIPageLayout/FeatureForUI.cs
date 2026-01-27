using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class FeatureForUI : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/FeatureForUI.cshtml");
        }
    }
}
