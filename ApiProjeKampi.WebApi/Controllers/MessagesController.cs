using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Dtos.MessageDtos.MessageDtosForAdminThema.MessageListForNavbarSection;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiProjeContext _apiProjeContext;
        public MessagesController(IMapper mapper, ApiProjeContext apiProjeContext)
        {
            _mapper = mapper;
            _apiProjeContext = apiProjeContext;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _apiProjeContext.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var values = _mapper.Map<Message>(createMessageDto);
            _apiProjeContext.Messages.Add(values);
            _apiProjeContext.SaveChanges();
            return Ok("Ekleme başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var values = _apiProjeContext.Messages.Find(id);
            _apiProjeContext.Messages.Remove(values);
            _apiProjeContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetByIdMessage")]
        public IActionResult GetByIdMessage(int id)
        {
            var values = _apiProjeContext.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(values));
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<Message>(updateMessageDto);
            _apiProjeContext.Messages.Update(values);
            _apiProjeContext.SaveChanges();
            return Ok("Güncelleme başarılı");
        }

        [HttpGet("MessageListByIsReadFalse")]
        public IActionResult MessageListByIsReadFalse()
        {
            var values = _apiProjeContext.Messages.Where(x => !x.IsRead).ToList();
            return Ok(_mapper.Map<List<MessageListByIsReadFalseDto>>(values));
        }
    }
}
