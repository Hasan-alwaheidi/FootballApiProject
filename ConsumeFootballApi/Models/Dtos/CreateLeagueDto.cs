namespace ConsumeFootballApi.Models.Dtos
{
    public class CreateLeagueDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Season { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
