using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForAdmin
{
    public class HeadForAdmin : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForAdmin/HeadForAdmin.cshtml");
        }
    }
}
