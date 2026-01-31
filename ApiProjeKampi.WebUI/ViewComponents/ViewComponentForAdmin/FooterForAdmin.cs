using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForAdmin
{
    public class FooterForAdmin : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForAdmin/FooterForAdmin.cshtml");
        }
    }
}
