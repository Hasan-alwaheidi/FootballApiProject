namespace FootballApiProject.Models.DTO_s.TeamsDto
{
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public string StadiumName { get; set; }
        public string LeagueName { get; set; }
        public string? LogoPath { get; set; } = "/images/default.jpg";
        public string? Description { get; set; }  

    }

}
