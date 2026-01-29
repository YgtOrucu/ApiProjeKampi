namespace ApiProjeKampi.WebApi.Dtos.MessageDtos.MessageDtosForAdminThema.MessageListForNavbarSection
{
    public class MessageListByIsReadFalseDto
    {
        public int MessageId { get; set; }
        public string? NameSurname { get; set; }
        public string? Subject { get; set; }
        public DateTime SendDate { get; set; }
    }
}
