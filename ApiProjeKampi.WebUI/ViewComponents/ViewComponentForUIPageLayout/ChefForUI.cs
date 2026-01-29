using ApiProjeKampi.WebUI.Dtos.ChefDto;
using ApiProjeKampi.WebUI.Dtos.YummyEvenetDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class ChefForUI : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChefForUI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Chefs");
            if (responsemessage.IsSuccessStatusCode)
            {
                var JsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(JsonData);
                return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/ChefForUI.cshtml", values);
            }
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/ChefForUI.cshtml");

        }
    }
}
