using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForAdmin
{
    public class ProfileDropdownInTheNavbarForSection : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ViewComponentForAdmin/ProfileDropdownInTheNavbarForSection.cshtml");
        }
    }
}
