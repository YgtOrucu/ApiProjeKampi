using ApiProjeKampi.WebUI.Dtos.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class CategoryForUI : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryForUI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Categories");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/CategoryForUI.cshtml", values);
            }
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/CategoryForUI.cshtml");
        }
    }
}
