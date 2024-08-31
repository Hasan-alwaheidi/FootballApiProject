namespace ConsumeFootballApi.Models.Dtos
{
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public int StadiumId { get; set; }
        public int LeagueId { get; set; }
        public string Coach { get; set; }
        public IFormFile? Logo { get; set; } 
        public string? LogoPath { get; set; }
    }
}
