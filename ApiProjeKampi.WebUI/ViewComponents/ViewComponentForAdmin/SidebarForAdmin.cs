using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForAdmin
{
    public class SidebarForAdmin : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForAdmin/SidebarForAdmin.cshtml");
        }
    }
}
