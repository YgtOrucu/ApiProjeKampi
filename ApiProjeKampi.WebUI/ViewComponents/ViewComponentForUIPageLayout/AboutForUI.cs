using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class AboutForUI : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/AboutForUI.cshtml");
        }
    }
}
