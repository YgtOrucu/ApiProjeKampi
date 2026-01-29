namespace ApiProjeKampi.WebApi.Dtos.TestimonialDtos
{
    public class GetByIdTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string? NameSurname { get; set; }
        public string? Title { get; set; }
        public string? Commment { get; set; }
        public string? ImageUrl { get; set; }
    }
}
