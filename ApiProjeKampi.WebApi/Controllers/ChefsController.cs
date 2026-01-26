using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiProjeContext _apiProjeContext;
        public ChefsController(ApiProjeContext apiProjeContext)
        {
            _apiProjeContext = apiProjeContext;
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _apiProjeContext.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _apiProjeContext.Chefs.Add(chef);
            _apiProjeContext.SaveChanges();
            return Ok("Şef ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var values = _apiProjeContext.Chefs.Find(id);
            _apiProjeContext.Chefs.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Şef Silme Başarılı");
        }

        [HttpGet("GetChefById")]
        public IActionResult GetChefById(int id)
        {
            var values = _apiProjeContext.Chefs.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _apiProjeContext.Chefs.Update(chef);
            _apiProjeContext.SaveChanges();
            return Ok("Şef Güncellendi");
        }
    }
}
