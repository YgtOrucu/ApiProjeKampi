using ApiProjeKampi.WebUI.Dtos.YummyEvenetDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class YummyEventForUI : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public YummyEventForUI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/YummyEvents");
            if (responsemessage.IsSuccessStatusCode)
            {
                var JsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultYummyEventDto>>(JsonData);
                return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/YummyEventForUI.cshtml", values);
            }
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/YummyEventForUI.cshtml");

        }
    }
}
