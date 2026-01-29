using ApiProjeKampi.WebUI.Dtos.NotificationDto.NotificationDtosForAdminThema.NotificationListForNavbarSection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForAdmin
{
    public class NotificationListInTheNavbarForSection : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationListInTheNavbarForSection(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7233/api/Notifications/NotificationListForAdminPage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<NotificationList>>(JsonData);
                return View("~/Views/Shared/Components/ViewComponentForAdmin/NotificationListInTheNavbarForSection.cshtml", values);
            }
            return View("~/Views/Shared/Components/ViewComponentForAdmin/NotificationListInTheNavbarForSection.cshtml");
        }
    }
}
