using ApiProjeKampi.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class ServiceForUI : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceForUI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Services");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/ServiceForUI.cshtml",values);
            }
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/ServiceForUI.cshtml");
        }
    }
}
