namespace ConsumeFootballApi.Models.Dtos
{
    public class UpdateLeagueDto
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Season { get; set; }
        public IFormFile? Logo { get; set; }
        public string? ExistingLogoPath { get; set; }
    }
}
