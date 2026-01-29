using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiProjeContext _apiProjeContext;

        public YummyEventsController(ApiProjeContext apiProjeContext)
        {
            _apiProjeContext = apiProjeContext;
        }
        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _apiProjeContext.YummyEvents.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent YummyEvent)
        {
            _apiProjeContext.YummyEvents.Add(YummyEvent);
            _apiProjeContext.SaveChanges();
            return Ok("Etkinlik ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var values = _apiProjeContext.YummyEvents.Find(id);
            _apiProjeContext.YummyEvents.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Etkinlik Silme Başarılı");
        }

        [HttpGet("GetYummyEventById")]
        public IActionResult GetYummyEventById(int id)
        {
            var values = _apiProjeContext.YummyEvents.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent YummyEvent)
        {
            _apiProjeContext.YummyEvents.Update(YummyEvent);
            _apiProjeContext.SaveChanges();
            return Ok("Etkinlik Güncellendi");
        }
    }
}
