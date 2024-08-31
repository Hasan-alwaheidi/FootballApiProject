namespace FootballApiProject.Models.DTO_s
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public string? LogoPath { get; set; }
        public string StadiumName { get; set; }
        public string LeagueName { get; set; }
        public int StadiumId { get; set; }  
        public int LeagueId { get; set; }
        public string? Description { get; set; }  


    }
}
