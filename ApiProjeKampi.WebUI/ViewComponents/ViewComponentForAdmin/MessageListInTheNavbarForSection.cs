using ApiProjeKampi.WebUI.Dtos.MessageDto.MessageDtosForAdminThema.MessageListForNavbarSection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiProjeKampi.WebUI.ViewComponents.ViewComponentForAdmin
{
    public class MessageListInTheNavbarForSection : ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public MessageListInTheNavbarForSection(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7233/api/Messages/MessageListByIsReadFalse");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MessageListByIsReadFalseDto>>(JsonData);
                return View("~/Views/Shared/Components/ViewComponentForAdmin/MessageListInTheNavbarForSection.cshtml", values);
            }
            return View("~/Views/Shared/Components/ViewComponentForAdmin/MessageListInTheNavbarForSection.cshtml");
        }
    }
}
