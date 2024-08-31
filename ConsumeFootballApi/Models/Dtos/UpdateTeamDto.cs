namespace ConsumeFootballApi.Models.Dtos
{
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int StadiumId { get; set; }
        public int LeagueId { get; set; }
        public string Coach { get; set; }
        public IFormFile? Logo { get; set; } 
        public string? LogoPath { get; set; }
    }
}
