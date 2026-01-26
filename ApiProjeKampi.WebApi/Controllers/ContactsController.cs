using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiProjeContext _apiProjeContext;
        public ContactsController(ApiProjeContext apiProjeContext)
        {
            _apiProjeContext = apiProjeContext;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _apiProjeContext.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var values = new Contact
            {
                Address = createContactDto.Address,
                Email = createContactDto.Email,
                MapLocation = createContactDto.MapLocation,
                OpenHours = createContactDto.OpenHours,
                Phone = createContactDto.Phone,

            };
            _apiProjeContext.Contacts.Add(values);
            _apiProjeContext.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _apiProjeContext.Contacts.Find(id);
            _apiProjeContext.Contacts.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
        [HttpGet("GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var values = _apiProjeContext.Contacts.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContact)
        {
            var values = new Contact
            {
                ContactId = updateContact.ContactId,
                Address = updateContact.Address,
                Email = updateContact.Email,
                MapLocation = updateContact.MapLocation,
                OpenHours = updateContact.OpenHours,
                Phone = updateContact.Phone
            };

            _apiProjeContext.Contacts.Update(values);
            _apiProjeContext.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
