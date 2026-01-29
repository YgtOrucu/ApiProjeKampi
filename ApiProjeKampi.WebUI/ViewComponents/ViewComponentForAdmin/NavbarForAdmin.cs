using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForAdmin
{
    public class NavbarForAdmin : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForAdmin/NavbarForAdmin.cshtml");
        }
    }
}
