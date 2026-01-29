using ApiProjeKampi.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForUIPageLayout
{
    public class TestimonialForUI:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialForUI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Testimonials");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/TestimonialForUI.cshtml", values);
            }
            return View("~/Views/Shared/Components/ViewComponentForUIPageLayout/TestimonialForUI.cshtml");
        }
    }

}
