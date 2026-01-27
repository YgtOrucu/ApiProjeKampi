using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class MenuForUI : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/MenuForUI.cshtml");
        }
    }
}
