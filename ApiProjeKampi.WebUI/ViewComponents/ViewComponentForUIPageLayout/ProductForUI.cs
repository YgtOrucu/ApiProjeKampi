using ApiProjeKampi.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class ProductForUI : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductForUI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Products");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/ProductForUI.cshtml", values);
            }
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/ProductForUI.cshtml");
        }
    }
}
