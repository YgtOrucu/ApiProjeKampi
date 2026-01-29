using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.NotificationDtos;
using ApiProjeKampi.WebApi.Dtos.NotificationDtos.NotificationDtosForAdminThema.NotificationListForNavbarSection;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApiProjeContext _apiProjeContext;
        private readonly IMapper _mapper;

        public NotificationsController(ApiProjeContext apiProjeContext, IMapper mapper)
        {
            _apiProjeContext = apiProjeContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _apiProjeContext.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult NotificationCreate(CreateNotificationDto createNotificationDto)
        {
            var values = _mapper.Map<Notification>(createNotificationDto);
            _apiProjeContext.Notifications.Add(values);
            _apiProjeContext.SaveChanges();
            return Ok("Not oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult NotificationDelete(int id)
        {
            var values = _apiProjeContext.Notifications.Find(id);
            _apiProjeContext.Notifications.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult NotificationUpdate(UpdateNotificationDto updateNotificationDto)
        {
            var values = _mapper.Map<Notification>(updateNotificationDto);
            _apiProjeContext.Notifications.Update(values);
            _apiProjeContext.SaveChanges();
            return Ok("Güncelleme Başarılı");
        }
        [HttpGet("GetByIdNotification")]
        public IActionResult GetByIdNotification(int id)
        {
            var values = _apiProjeContext.Notifications.Find(id);
            return Ok(_mapper.Map<GetByIdNotificationDto>(values));
        }
        [HttpGet("NotificationListForAdminPage")]
        public IActionResult NotificationListForAdminPage()
        {
            var values = _apiProjeContext.Notifications.ToList();
            return Ok(_mapper.Map<List<NotificationList>>(values));
        }
    }
}
