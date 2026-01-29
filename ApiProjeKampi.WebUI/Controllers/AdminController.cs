using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class AdminController : Controller
    {


        #region Category

        #region CategoryList
        public IActionResult CategoryList()
        {
            return View();
        }

        #endregion

        #endregion 
    }
}
